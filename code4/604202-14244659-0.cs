    public IEnumerable<Bank_Configuration>  SelectBankConfiguration()
    {
        using (EFEntities objEFEntities = new EFEntities())
        {                             
            var Result= from c in objEFEntities.Bank_Configuration 
                        select c;
            return Result.ToArray();
        }            
    }
