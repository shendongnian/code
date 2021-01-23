            string[] fileNames = Directory.GetFiles(path);
            List<string> fileNamesWithoutExtension = new List<string>(); 
            List<string> myFiles = new List<string>();
          
            string myFile = mySearchFileWithoutExtension;
            foreach (string s in fileNames)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                string s1 = new string(charArray);
                string[] ext = s1.Split(new char[] { '.' }, 2);
                if ((ext.Length > 1))
                {
                    char[] charArray2 = ext[1].ToCharArray();
                    Array.Reverse(charArray2);
                    fileNamesWithoutExtension.Add(new string(charArray2));
                    if ((new string(charArray2)).Trim().Equals(myFile))
                    {
                        myFiles.Add(s);
                    }
                }
            }
