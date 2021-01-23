                string str = "price+10*discount-30";
            char[] delimiters = new char[] { '+', '1', '0', '*', '-', '3'};
            string[] parts = str.Split(delimiters,
                             StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in parts)
                Console.WriteLine(s);
            Console.ReadLine();
