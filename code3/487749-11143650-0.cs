    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string inputstr = Console.ReadLine();
                
               Console.WriteLine(string.Format("{0} = {1}", inputstr, getMD5hash(inputstr)));
    
                Console.ReadKey();
    
           
         
            }
    
            public static string getMD5hash(string input)
            {
                //create a new instance of MD5 object
                MD5 md5Hasher = MD5.Create();
                //convert the input value to byte array
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
    
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
    
            
        }
    }
