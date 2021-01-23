     public class Library
        {
            public Library()
            { }
            private static Library _secondInstance = new Library();
            private static Library _librarySingleton = new Library();
            public Library Second()
            {
                return _secondInstance;
            }
            public static Library Instance
            {
                get
                {
                    return _librarySingleton;
                }
            }
            //library internally uses singleton too!!
        }
