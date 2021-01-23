        public void UpdateAccount()
        {
            //Used value from previous select
            DateTime previousDateTime = new DateTime(2012, 6, 25, 17, 8, 32, 677);
            
            RepositoryLayer.Account accEntity = new RepositoryLayer.Account();
            accEntity.AccountNumber = 1; //Primary Key
            accEntity.ModifiedTime = previousDateTime; //Concurrency column
            accountRepository.UpdateChangesByAttach(accEntity);
            
            //Values to be modified after Attach
            accEntity.AccountType = "NEXT";
            accEntity.ModifiedTime = DateTime.Now;
            accEntity.Duration = 4;
            accountRepository.SubmitChanges();
        }
        public virtual void UpdateChangesByAttach(T entity)
        {
            
            if (Context.GetTable<T>().GetOriginalEntityState(entity) == null)
            {
                //If it is not already attached
                Context.GetTable<T>().Attach(entity);
            }
           
        }
