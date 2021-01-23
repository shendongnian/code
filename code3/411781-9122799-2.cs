    [assembly: InternalsVisibleTo("MyCode.UnitTests")]
    namespace MyCode.MyWatch
    {
        #pragma warning disable CS0628 //invalid because of InternalsVisibleTo
        public sealed class MyWatch
        {
            Func<DateTime> _getNow = delegate () { return DateTime.Now; };
        
    
           //construktor for testing purposes where you "can change DateTime.Now"
           internal protected MyWatch(Func<DateTime> getNow)
           {
               _getNow = getNow;
           }
    
           public MyWatch()
           {            
           }
       }
    }
