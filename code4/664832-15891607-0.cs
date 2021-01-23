    public static class MyInvokeExtension
    {
       public static void TempInvoke(this objectthatsupportsinvoke, ...)
       {
            try
            {
               objectthatsupportsinvoke.Invoke(...);
            }
            catch(Exception ex)
            {
               Console.WriteLine();  // put a break-point here
            }
       }
        
       // add other BeginInvoke and EndInvoke methods and do the same as above.
    }
