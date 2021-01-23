        public List<string> ReadFileToList(string path)
        {
            List<string> temp = new List<string>();
            using (StreamReader r = new StreamReader(path))
            {
                string line;
                if ((line = r.ReadLine()) != null)
                {
                    temp =line.Split(',').ToList();
                }
            }
            return temp;
        }
