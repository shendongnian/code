        //A list of chars that we are going to replace with \s"char"\s this list may not be complete.
        // . is not in here. We will take care of that later.
        static string[] specChars = new string[] { "<", ">", "<=", ">=", "=", "like", "in", "between", "or", "and", "(", ")", "where" };
        static string[] delims = new string[] {"and", "or", "where" };
        static string testData = @"WHERE transactions.status_code= 'AFA 2'
        AND (transactions.supp_ref = supplier.supp_ref
        AND supplier.supp_addr_ref = address.addr_ref)
        OR transactions.user_code = user.user_code";
        static void Main(string[] args)
        {
            Print(Parse(testData));
            Console.ReadKey();
        }
        static List<List<string>> Parse(string input)
        {
            List<List<string>> ret = new List<List<string>>();
            //lets remove all the spaces first becaue we are going to put them back
            //the way we want to see them.
            input = input.Replace(" ", "").Replace("\r", "").Replace("\n", "").ToLower();
            foreach (string item in specChars)
            {
                //this will help clean the string so you can use it
                input = input.Replace(item, string.Format(" {0} ", item));   
            }
            string[] splits = input.Split(' ');
            List<string> currList = null;
            foreach (string item in splits.Where(x => x.Length > 0))
            {
                if (delims.Contains(item))
                {
                    if (currList != null)
                    {
                        ret.Add(currList);
                        currList = new List<string>();
                        currList.Add(item);
                    }
                    else
                    {
                        currList = new List<string>();
                        currList.Add(item);
                    }
                }
                else
                {
                    if (item.Contains("."))
                    {
                        string[] tmp = item.Split('.');
                        currList.Add(tmp[0]);
                        currList.Add(tmp[1]);
                    }
                    else
                        currList.Add(item);
                }
            }
            if (currList != null)
                ret.Add(currList);
            return ret;
        }
        static void Print(List<List<String>> input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (List<String> item in input)
            {
                sb.Append("New Chunk:\n");
                foreach (string str in item)
                {
                    sb.Append(string.Format("\t{0}\n", str));
                }
                sb.Append("\n");
            }
            Console.WriteLine(sb.ToString());
        }
    }
