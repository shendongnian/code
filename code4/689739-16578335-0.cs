            string[] strList1 = new string[] { "TDC1ABF TDC1ABI TDC1ABO" };
            for (int x = 0; x < strList1.Length; x++)
            {
                char[] temp = strList1[x].ToCharArray();
                int sum = 0;
                foreach (char letter in temp)
                {
                    sum += (int)letter; //This adds the ASCII value of each char 
                }
                Console.WriteLine(sum.ToString());
            }
