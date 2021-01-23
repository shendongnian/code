       public class Foo 
        {
           public string Property1 { get; set; }
        }
        
        public class InheritsFoo : Foo 
        {
            public static void AssignDel<TVal>(
                Expression<Func<InheritsFoo, TVal>> expr, 
                Action<InheritsFoo, TVal> action) 
            {
            }
        }
