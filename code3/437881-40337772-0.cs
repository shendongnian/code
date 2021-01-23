    public static int Fibonatchi(int position)
        {
            if(position == 0)
            {
                return 1;
            }
            if(position == 1)
            {
                return 1;
            }
            
            else
            {
                return Fibonatchi(position - 2) + Fibonatchi(position - 1);
            }
          
            
        }
    }
