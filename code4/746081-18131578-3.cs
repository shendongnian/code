        public static List<SPResult> GetListOfTextBox(string varchar1, string, varchar2)
        {
            using (var db = new EDMXEntities())
            {
                //GetTextBoxValue is the name you gave to the function import
                ObjectResult<SPResult> Results = db.GetTextBoxValue(varchar1, varchar2);
                List<SPResult> results = Results.ToList();
                return results;
            }
        }
