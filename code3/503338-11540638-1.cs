    public class yourClass
        {
            public readonly int x = generateInt();
    
            public static int generateInt()
            {
                return DateTime.Now.Millisecond; // or any other method getSomeInt();
            }
        }
