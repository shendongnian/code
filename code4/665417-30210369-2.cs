     public class Car
        {
            private static Car m_Singleton = new Car();
            public static void DoSomething()
            {
                m_Singleton.NonStaticMethod();
            } 
