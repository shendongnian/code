    public bool GetNumberFromStr(string str)
        {
            string ss = "";
            foreach (char s in str)
            {
                int a = 0;
                if (int.TryParse(Convert.ToString(s), out a))
                    ss += a;
            }
            if ss.Length >0
               return true;
            else
               return false;
        } 
