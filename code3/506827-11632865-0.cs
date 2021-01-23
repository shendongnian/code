    double _mfe;
    double _mae;
            public double mfe
            {
                 get
                 {
                    return Math.Round((decimal)_mfe, 4, MidpointRounding.AwayFromZero)
                 }
                 set
                 {
                     _mfe = value;
                 }
            }
    
            public double mae
            {
                 get
                 {
                    return Math.Round((decimal)_mae, 4, MidpointRounding.AwayFromZero)
                 }
                 set
                 {
                     _mae= value;
                 }
            }
          
