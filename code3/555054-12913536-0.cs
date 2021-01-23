    void YourMethod()
    {
    using (Entities context = new Entities())
            {
                try
                {
                    context.Office.Add(office);
                    retVal = context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    SqlException innerException = ex.GetBaseException() as SqlException;
                    if (innerException != null && innerException.Number == (int)SQLErrorCode.DUPLICATE_UNIQUE_CONSTRAINT)
                    {
                        throw
                            new Exception("Error ocurred");
                    }
                    //This is momenty where exception is thrown.
                    else
                    {
                        throw ex;
                    }
                }
            }
    }
