        static void Main(string[] args)
        {
            String str = "a,b,\"c,d\",e,f,\"g,h\",i,j,k,l,\"m,n,o\"";
            int firstQuoteIndex = 0;
            int secodQuoteIndex = 0;
            Console.WriteLine(str);
            bool iteration = false;
            //String manipulation
            //if count is even then count/2 is the number of pairs of double quotes we are having
            //so we have to traverse count/2 times.
            int count = str.Count(s => s.Equals('"'));
            if (count >= 2)
            {
                firstQuoteIndex = str.IndexOf("\"");
                for (int i = 0; i < count / 2; i++)
                {
                    if (iteration)
                    {
                        firstQuoteIndex = str.IndexOf("\"", firstQuoteIndex + 1);
                    }
                    secodQuoteIndex = str.IndexOf("\"", firstQuoteIndex + 1);
                    string temp = str.Substring(firstQuoteIndex + 1, secodQuoteIndex - (firstQuoteIndex + 1));                    
                    firstQuoteIndex = secodQuoteIndex + 1;
                    if (count / 2 > 1)
                        iteration = true;                    
                    string temp2= temp.Replace(',', ';');
                    str = str.Replace(temp, temp2);
                    Console.WriteLine(temp);
                }
            }
            Console.WriteLine(str);
            Console.ReadLine();
        }
