        public static List<String> GetTextListFromDiskFile(String fileName)
        {
            List<String> list = new List<String>();
            try
            {
                //load the file into the streamreader 
                System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                //loop through each line of the file
                while (sr.Peek() >= 0)
                {
                    list.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                list.Add("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            return list;
        }
