    static void Main(string[] args)
            {
                string a = "8fcc44";
                string result = string.Empty;
    
                for (int i = 0; i < a.Length; i+=2)
                {
                    result += "0x" + a.Substring(i,2);
                }
    
                Console.WriteLine(result);
            }
