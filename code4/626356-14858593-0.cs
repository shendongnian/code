            public List<DbEntityValidationException> vErrors = new List<DbEntityValidationException>();
            public int DbChanges = 0;      
            public bool SaveChanges()
            {
                try
                {
                    this.vErrors = (List<DbEntityValidationException>)base.GetValidationErrors();
                    if (this.vErrors.Count == 0)
                    {
                        this.DbChanges = base.SaveChanges();
                        return true;
                    }
                }
                catch (Exception Ex)
                {
                    this.vErrors.Add(new DbEntityValidationException(string.Format("General Error: {0}", Ex.GetType().ToString())));
                }
                return false;
            }
