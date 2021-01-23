        class Program
        {
            static void Main(string[] args)
            {
                byte[] encoded =
                    {
                        0x01, 0x00, 0x00, 0x24, 0x02, 0x43, 0x31, 0x31, 0x00, 0x00, 0x01, 0x43, 0x49, 0x53, 0x2D,
                        0x34, 0x36, 0x58, 0x58, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x11
                    };
    
                byte[] toCheck = SubArray<byte>(encoded, 8, 5); // start index at 8 and u need till 12th
    
                if (toCheck[0] != '\0')
                {
                    Console.WriteLine(Encoding.ASCII.GetString(toCheck));
                }
    
                Console.Read();
            }
    
            public static T[] SubArray<T>(T[] data, int index, int length)
            {
                T[] result = new T[length];
                Array.Copy(data, index, result, 0, length);
                return result;
            }
    
        }
