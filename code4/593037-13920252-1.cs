    private static object _lockObj = new object();
    
    public int getCurrentValue(int valueID)
         {
            object value;
            
            lock(_lockObj)
              {
               value = // read value from DB
              }
            return value;
         }
    
    public void updateValues(int componentID)
         {
             lock(_lockObj)
              {
             // update values in DB
    
              }
         }
