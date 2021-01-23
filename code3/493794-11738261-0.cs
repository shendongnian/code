        public IList<string> GetAccountType()
                {
                    using (var db = new DataClasses1DataContext())
                    {
                        var  acctype = db.mem_types.Select(account=>account.CustCategory).Distinct().ToList();
                        if (acctype != null)
                        {
                            return acctype;
                        }
                    }
                    return acctype;
                }
