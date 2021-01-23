        // GET api/Transactions/5
        [Route("api/Transactions/{id:int}")]
        public Transaction Get(int id)
        {
            return _transactionRepository.GetById(id);
        }
        [Route("api/Transactions/{code}")]
        public Transaction Get(string code)
        {
            try
            {
                return _transactionRepository.Search(p => p.Code == code).Single();
            }
            catch (Exception Ex)
            {
                System.IO.File.WriteAllText(@"C:\Users\Public\ErrorLog\Log.txt",
                    Ex.Message + Ex.StackTrace + Ex.Source + Ex.InnerException.InnerException.Message);
            }
            return null;
        }
