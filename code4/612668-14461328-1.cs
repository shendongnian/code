        private static bool Check(string input)
        {
            int count = 0;
            foreach (string segment in input.Split('~'))
            {
                string[] tokens = segment.Split('*');
                if (tokens[0] == "AAA")
                {
                    count++;
                    if (count == 3)
                    {
                        if (tokens[3] == "63") return true;
                        else return false;
                    }
                }
            }
            return false;
        }
