    class Shapes
    {
        int _radius;
    
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
    }
    
    
    class HeaxGon:Shapes
    {
        int points;
        
        public void SetRadius()
        {
            Radius=20;
        }
    }
