    public class classHasher
        {
            /**********
    		*	recursive folder MD5 hash of a dir
    		*/
            MD5 hashAlgo = null;
            StringBuilder sb;
            public classHasher()
            {
                hashAlgo = new MD5CryptoServiceProvider();
            }
    
            public string UltraHasher(String path)
            { 
                /**********
                *   recursive folder MD5 hash of a dir
                */
                if (!Directory.Exists(path))
                {
                    return  getHashOverFile(path);
                }
    
                List<string> filemd5s = new List<string>();
                List<string> dir = new List<string>();
    
                if (Directory.GetDirectories(path) != null) foreach (var d in Directory.GetDirectories(path))
                {
                    dir.Add(d);
                    
                }
                if (Directory.GetFiles(path) != null) foreach (var f in Directory.GetFiles(path))
                {
                    dir.Add(f);                
                }
    
                dir.Sort();
    
                foreach (string entry in dir)
                {
                    if (Directory.Exists(entry))
                    {
                        string rtn = UltraHasher(entry.ToString());
                        //Debug.WriteLine("   ULTRRAAHASHER:! " + entry.ToString() + ":" + rtn);
                        filemd5s.Add(rtn); 
                    } 
                    if (File.Exists(entry))
                    {
                        string rtn = getHashOverFile(entry.ToString());
                        //Debug.WriteLine("   FILEEEEHASHER:! " + entry.ToString() + ":" + rtn);
                        filemd5s.Add(rtn);
                    }
                }
    
                //Debug.WriteLine("   ULTRRAASUMMMM:! " + String.Join("", filemd5s.ToArray()));
                string tosend = CalculateMD5Hash(String.Join("", filemd5s.ToArray()));
                //Debug.WriteLine("   YEAHHAHHAHHAH:! " + tosend);
                return tosend;
            }
    
            public string getHashOverFile(String filename)
            {
                sb = new StringBuilder();
                getFileHash(filename);
                return sb.ToString();
            }
            private void getFileHash(String f)
            {
                using (FileStream file = new FileStream(f, FileMode.Open, FileAccess.Read))
                {
                    byte[] retVal = hashAlgo.ComputeHash(file);
                    file.Close();
                    foreach (var y in retVal)
                    {
                        sb.Append(y.ToString("x2"));
                    }
                }
            }
            public string CalculateMD5Hash(string input)
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hash = hashAlgo.ComputeHash(inputBytes);
    
                StringBuilder sz = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sz.Append(hash[i].ToString("x2"));
                }
                return sz.ToString();
            }
     }
