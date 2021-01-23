    public IList<string> GetAccountType()
    {
            var acctype = new List<string>();
            using (var db = new DataClasses1DataContext())
            {
                acctype = db.mem_types.Select(
                             account=>account.CustCategory).Distinct().ToList();
            }
            return acctype;
        }
