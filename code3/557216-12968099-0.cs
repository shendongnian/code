    using System;
    
    namespace ConsoleApplication6
    {
        public enum Events
        {
            Event1 = 10001,
            Event2 = 10002,
            Event3 = 10003,
            Event4 = 10004,
            Event5 = 10005,
            Event6 = 10006,
            Event7 = 10007,
            Event8 = 10008,
            Event9 = 10009,
            Event10 = 10010
        }
    
        public class Program
        {
            public static event Action Event1;
            public static event Action Event2;
            public static event Action Event3;
            public static event Action Event4;
            public static event Action Event5;
            public static event Action Event6;
            public static event Action Event7;
            public static event Action Event8;
            public static event Action Event9;
            public static event Action Event10;
    
            private static void OnEvent1()
            {
                if(Event1 != null)
                {
                    Event1();
                }
            }
    
            private static void OnEvent2()
            {
                if (Event2 != null)
                {
                    Event2();
                }
            }
    
            private static void OnEvent3()
            {
                if (Event3 != null)
                {
                    Event3();
                }
            }
    
            private static void OnEvent4()
            {
                if (Event4 != null)
                {
                    Event4();
                }
            }
    
            private static void OnEvent5()
            {
                if (Event5 != null)
                {
                    Event5();
                }
            }
    
            private static void OnEvent6()
            {
                if (Event6 != null)
                {
                    Event6();
                }
            }
    
            private static void OnEvent7()
            {
                if (Event7 != null)
                {
                    Event7();
                }
            }
    
            private static void OnEvent8()
            {
                if (Event8 != null)
                {
                    Event8();
                }
            }
    
            private static void OnEvent9()
            {
                if (Event9 != null)
                {
                    Event9();
                }
            }
    
            private static void OnEvent10()
            {
                if (Event10 != null)
                {
                    Event10();
                }
            }
    
            static void Main(string[] args)
            {
                while(true)
                {
                    var input = Console.ReadLine();
    
                    if(input == "q")
                    {
                        return;
                    }
    
                    int value;
    
                    if(int.TryParse(input, out value))
                    {
                        var eventValue = (Events) value;
                        var eventName = Enum.GetName(typeof (Events), eventValue);
    
                        var matchingEvent = typeof(Program).GetEvent(eventName);
    
                        if (matchingEvent != null)
                        {
                            var action = new Action(() => Console.WriteLine("Event " + eventName + " has been handled"));
                            matchingEvent.AddEventHandler(null, action);
                        }
                        
                    }
    
                    OnEvent1();
                    OnEvent2();
                    OnEvent3();
                    OnEvent4();
                    OnEvent5();
                    OnEvent6();
                    OnEvent7();
                    OnEvent8();
                    OnEvent9();
                    OnEvent10();
                }
            }
        }
    }
