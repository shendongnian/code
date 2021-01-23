     void DisplayNumbersOfName(string name)
     {
        using (dataclassDataContext db = new dataclassDataContext())
        {
            var Names = from ta in db.table_accounts
                        where (String.IsNullOrEmpty(name) || ta.name == name)
                        select ( ta );
        }
     }
