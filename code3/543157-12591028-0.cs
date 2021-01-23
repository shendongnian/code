        public static void Main()
        {
            string src = "&$filter=statuscode/Value eq 179640000 and new_Approved/Value eq 179640000";
            Regex regex = new Regex(@"(\w*)/Value eq (\w*)");
            foreach (Match m in regex.Matches(src))
            {
                foreach (Group g in m.Groups)
                {
                    Console.WriteLine(g.Value);
                }
            }
        }
