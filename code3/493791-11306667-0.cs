    public IList<string> GetAccountType()
    {
            var listToReturn = new List<string>();
            using (var db = new DataClasses1DataContext())
            {
                var  acctype = db.mem_types.Select(
                                account=>account.CustCategory).Distinct().ToList();
                if (acctype != null)
                {
                    listToReturn = acctype;
                }
            }
            return listToReturn;
        }
