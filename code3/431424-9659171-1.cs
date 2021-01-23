    using System;
    
    class Sample 
    {
        public static void Main() 
        {
              Console.WriteLine("GetFolderPath: {0}", 
                     Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        }
    }
 
