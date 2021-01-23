    class MyCustomDataStore
    {
         long[] array;
         
         MyCustomDataStore() 
         {
              array = new long[128 | 128 << 7];
         }
    
         bool get(int px, int py, int pz) 
         {
              return (array[px | (py << 7)] & (1 << pz)) == 0;
         }
    
         void set(int px, int py, int pz, bool val) 
         {
              long mask = (1 << pz);
              int index = px | (py << 7);
              if (val)
              {
                   array[index] |= mask;
              }
              else
              {
                   array[index] &= ~mask;
              }
         }
    }
