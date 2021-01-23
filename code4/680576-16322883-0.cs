    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Globalization;
    
    namespace CurrentCulture
    {
        public class Info : MarshalByRefObject
        {
            public void ShowCurrentCulture()
            {
                Console.WriteLine("Culture of {0} in application domain {1}: {2}",
                                  Thread.CurrentThread.Name,
                                  AppDomain.CurrentDomain.FriendlyName,
                                  CultureInfo.CurrentCulture.Name);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Info inf = new Info();
                // Set the current culture to Dutch (Netherlands).
                Thread.CurrentThread.Name = "MainThread";
                Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
                inf.ShowCurrentCulture();
                Console.Read();
            }
        }
    }
