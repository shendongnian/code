    public delegate void MyDelegate<in T>(T type, ref bool keepGoing);
    
    public static void RunInLoop<T>(IEnumerable<T> someCollection, 
                                     MyDelegate<T> action)
    {           
            foreach (var item in someCollection)
            {
                    action(item, ref s_AnotherKeepGoing);
            }
    }
