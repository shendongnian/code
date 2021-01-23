    string splitter(string tosplit, int num, string splitstring)
        {
            string output = "";
            for (int i = 0; i < tosplit.Length; i += num)
                if (i + num < tosplit.Length)
                    output += tosplit.Substring(i, num) + ",";
                else
                    output += tosplit.Substring(i);
            return output;
        }
