                string str = "123.1.1.QWE";
                string[] seqnum = new string[2];
                foreach (char ch in str)
                {
                    if (char.IsNumber(ch) || ch == '.')
                    {
    
                    }
                    else
                    {
                        int indx = str.IndexOf(ch);
                        seqnum[0] =  str.Substring(0, indx).ToString();
                        seqnum[1] =  str.Substring(indx,str.Length-indx).ToString();
                        break;
                    }
                }
               
             // output
            //  seqnum[0]=123.1.1.
            //  seqnum[1]=QWE
