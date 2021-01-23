        public static void DicToExcel(Dictionary<string, string> dict, string path)
        {
            try
            {
                String csv = String.Join(Environment.NewLine,
                       dict.Select(d => d.Key + "," + d.Value));
                System.IO.File.WriteAllText(path, csv);
            }
            catch (Exception ex)
            {
                string res = ex.Message;
                //do somthing
            }
        }
