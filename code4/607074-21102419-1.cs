        // PUT api/Transactions/5
        [Route("api/Transactions/{id:int}")]
        public HttpResponseMessage Put(int id, Transaction transaction)
        {
            try
            {
                if (_transactionRepository.Save(transaction))
                {
                    return Request.CreateResponse<Transaction>(HttpStatusCode.Created, transaction);
                }
            }
            catch (Exception Ex)
            {
                System.IO.File.WriteAllText(@"C:\Users\Public\ErrorLog\Log.txt",
                    Ex.Message + Ex.StackTrace + Ex.Source + Ex.InnerException.InnerException.Message);
            }
            return Request.CreateResponse<Transaction>(HttpStatusCode.InternalServerError, transaction);
        }
