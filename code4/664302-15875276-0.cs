    public struct MyInt{
        private int p = default(int);
        public int theInt{  
            set{
                var v = value; 
                if(v > 255) 
                   v  =255; 
                else if(v < 0)
                   v = 0;
                p = v;
            }
            get{              
                return p;
            }
        }
      
    }
