    private static object _lockObj = new object();
    
    [MethodImpl(MethodImplOptions.Synchronized)]
    public int getCurrentValue(int valueID)
         {
            object value;
            
            lock(_lockObj)
              {
               value = // read value from DB
              }
            return value;
         }
    
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void updateValues(int componentID)
         {
             lock(_lockObj)
              {
             // update values in DB
    
              }
         }
