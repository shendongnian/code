    private List<string> GetThings(string fileName, int count)
        {
            string[] lines = File.ReadAllLines(fileName);
            List<string> result = new List<string>();
            foreach (string item in lines)
            {
                for (int i = 1; i <= count; i++)
                    result.Add(item + i.ToString());
            }
            return result;
        }
