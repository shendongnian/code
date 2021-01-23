     public static string[] method1()
        {
            //List<string[]> allLines = new List<string[]>();
            TextReader tr = new StreamReader("data.txt");
            // write a line of text to the file
            string word = tr.ReadLine();
    
            //now split this line into words
            string[] val = word.Split(new Char[] { ',' });
    
            //Console.WriteLine(val[0]);
            //Console.WriteLine(val[1]);
            //Console.ReadLine();
            return val;
        }
    
        public static void method2()
        {
    
            var value1 = method1();
    
            Console.WriteLine(value1.First());
            //Console.WriteLine(val[0]);
        }
