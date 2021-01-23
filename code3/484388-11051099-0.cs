     string str = "2,356,34";
             string[] newStr = str.Split(',');
             str = string.Empty;
             for (int i = 0; i <= newStr.Length-1; i++)
             {
                 if (i == newStr.Length-1)
                 {
                     str += "."+newStr[i].ToString();
                 }
                 else if (i == 0)
                 {
                     str += newStr[i].ToString();
                 }
                 else
                 {
                     str += "," + newStr[i].ToString();
                 }
             }
             string s = str;
