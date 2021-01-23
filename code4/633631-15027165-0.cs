    class Program
        {
            static void Main(string[] args)
            {
                string read = "A401,192,2,8" ;
    
                string[] readData = read.Split(new Char[] { ',' });
    
    
                //string[] readdata = read.Split(',');
                string a = readData[0];
                string b = readData[1] + "." + readData[2];
                string c = readData[3];
    
                Console.WriteLine(a + b + c);
            }
        }
