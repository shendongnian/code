    //Uses generic constraints so only objects that use the 
    //IGetDates interface can call this method.
    public bool Validate<T>(T stuff, out string message) where T : IGetDates
    {
         message = string.Empty;
         bool success = true;
         string[] dates = stuff.GetDates();
         for(int i = 0; i < dates.Length; i++)
         {
              if(!Validate(dates[i]))
              {
                  success = false;
                  message = string.Format("Date {0} is invalid.", i);
              }
         }
         return success;
    }
