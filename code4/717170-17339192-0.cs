        using VariousTesting;
        namespace VariousTesting
        {
        public class LibClass
            {        
                public static int num;
                public static void libMethod(int arg)
                {
                    num = arg;
                }
            }
        }
        namespace VariousTesting2
        {
            public class SubLibClassA : LibClass
            {
                public static int num;
                public static void libMethod(int arg)
                {
                    num = arg;
                }
                public static int GetNum()
                {
                    return num;
                }
            }
        }
        namespace VariousTesting2
        {
            public class SubLibClassB : LibClass
            {
                public static int num;
                public static void libMethod(int arg)
                {
                    num = arg;
                }
                public static int GetNum()
                {
                    return num;
                }
            }
        }
