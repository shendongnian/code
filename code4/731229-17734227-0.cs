    public class SpectroscopyObject
    {
         private FrequencyAbsorptionPointCollection _freqs = new FrequencyAbsorptionPointCollection ();
         public FrequencyAbsorptionPointCollection FrequecyAbsorption {get{ return _freqs;}}
         public int Id {get;set;}
    
         //other stuff...
    } 
    
    public struct Point 
    {
        public int X {get;set;}
        public int Y {get;set;}
    
        public Point ( int x , int y ) 
        {
                X = x;
                Y = y;
        }
    }
    
    public class FrequencyAbsorptionPoint
    {
        public double Frequency { get; set; }
        public Point Location { get; set; }
    }
    
    public class FrequencyAbsorptionPointCollection : IEnumerable<FrequencyAbsorptionPoint>
    {
        private readonly Dictionary<int , Dictionary<int , FrequencyAbsorptionPoint>> _points = new Dictionary<int , Dictionary<int , FrequencyAbsorptionPoint>> ( ); 
    
        int _xLeftMargin , _xRightMargin , _yTopMargin , _yBottomMargin;
        public FrequencyAbsorptionPointCollection (int xLeftBound,int xRightBound,int yTopBound,int yBottomBound)
        {
            _xLeftMargin = xLeftBound;
            _xRightMargin = xRightBound;
            _yTopMargin = yTopBound;
            _yBottomMargin = yBottomBound;
        }
    
        private bool XisSane(int testX)
        {
            return testX>_xLeftMargin&&testX<_xRightMargin;
        }
    
            
        private bool YisSane(int testY)
        {
            return testY>_yBottomMargin&&testY<_yTopMargin;
        }
    
        private bool PointIsSane(Point pointToTest)
        {
            return XisSane(pointToTest.X)&&YisSane(pointToTest.Y);
        }
        
        private const double DEFAULT_ABSORB_VALUE= 0.0;
        private bool IsDefaultAbsorptionFrequency(double frequency)
        {
            return frequency.Equals(DEFAULT_ABSORB_VALUE);
        }
    
        //I am assuming default to be 0
    
        public FrequencyAbsorptionPointCollection 
            (int xLeftBound,
             int xRightBound,
             int yTopBound,
             int yBottomBound,
             IEnumerable<FrequencyAbsorptionPoint> collection )
            :this(xLeftBound,xRightBound,yTopBound,yBottomBound)
        {
            AddCollection ( collection );
        }
    
        public void AddCollection ( IEnumerable<FrequencyAbsorptionPoint> collection ) 
        {
            foreach ( var point in collection )
            {
                Dictionary<int , FrequencyAbsorptionPoint> _current = null;
                if ( !_points.ContainsKey ( point.Location.X ) )
                {
                    _current = new Dictionary<int , FrequencyAbsorptionPoint> ( );
                    _points.Add ( point.Location.X , _current );
                }
                else
                    _current = _points [ point.Location.X ];
    
                if ( _current.ContainsKey ( point.Location.Y ) )
                    _current [ point.Location.Y ] = point;
                 else
                    _current.Add ( point.Location.Y , point );
            }
        }
    
        public FrequencyAbsorptionPoint this [ int x , int y ] 
        {
             get 
             {
                if ( XisSane ( x ) && YisSane ( y ) )
                {
                    if ( _points.ContainsKey ( x ) && _points [ x ].ContainsKey ( y ) )
                        return _points [ x ] [ y ];
                    else
                        return new FrequencyAbsorptionPoint
                    {
                        Id = 0 ,
                        Location = new Point ( x , y ) ,
                        Frequency = DEFAULT_ABSORB_VALUE
                    };
                }
                throw new IndexOutOfRangeException (
                    string.Format( "Selection ({0},{1}) is out of range" , x , y ));
            }
            set 
            {
                if ( XisSane ( x ) && YisSane ( y ) ) 
                {
                    if ( !IsDefaultAbsorptionFrequency ( value.Frequency ) ) 
                    {
                        Dictionary<int,FrequencyAbsorptionPoint> current = null;
                        if ( _points.ContainsKey ( x ) )
                            current = _points [ x ];
                        else
                        {
                            current = new Dictionary<int,FrequencyAbsorptionPoint>();
                            _points.Add ( x , current );
                        }
    
                        if ( current.ContainsKey ( y ) )
                            current [ y ] = value;
                        else
                        {
                            current.Add ( y , value );
                        }
                    }
                }
            }
        }
    
        public FrequencyAbsorptionPoint this [ Point p ] 
        {
            get 
            {
                return this [ p.X , p.Y ];
            }
            set 
            {
                this [ p.X , p.Y ] = value;
            }
        }
    
        public IEnumerator<FrequencyAbsorptionPoint> GetEnumerator ( )
        {
            foreach ( var i in _points.Keys )
                foreach ( var j in _points [ i ].Keys )
                    yield return _points [ i ] [ j ];
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ( )
        {
            return GetEnumerator ( );
        }
    }
