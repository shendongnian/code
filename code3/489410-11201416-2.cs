        public void UpdateAccount()
        {
            //Used value from previous select
            DateTime previousDateTime = new DateTime(2012, 6, 26, 11, 14, 15, 327);
            int prevDuration = 0;
            RepositoryLayer.Account accEntity = new RepositoryLayer.Account();
            accEntity.AccountNumber = 1; //Primary Key
            accEntity.ModifiedTime = previousDateTime; //Concurrency column
            //accEntity.Duration = prevDuration;
            accountRepository.UpdateChangesByAttach(accEntity);
            
            //Values to be modified after Attach
            accEntity.AccountType = "WIN-WIN";
            accEntity.ModifiedTime = DateTime.Now;
            try
            {
                accountRepository.SubmitChanges();
            }
            catch(System.Data.Linq.ChangeConflictException e)
            {
                throw new Exception(e.Message);
            }
        }
       public virtual void UpdateChangesByAttach(T entity)
        {
            if (Context.GetTable<T>().GetOriginalEntityState(entity) == null)
            {
                //If it is not already attached
                Context.GetTable<T>().Attach(entity);
            }
           
        }
