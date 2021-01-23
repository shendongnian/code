    public class TransactionsController : ApiController
    {
        public TransactionsController() : base()
        {
    
        }
    
        private static ConcurrentDictionary<Guid, Transaction> _transactions = new ConcurrentDictionary<Guid, Transaction>();
    
        /// <summary>
        /// Using to initiate the processing of a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost()]
        public HttpResponseMessage Post(Transaction transaction)
        {
            if(transaction == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError("Unable to model bind request."));
            }
    
            transaction.Id  = Guid.NewGuid();
    
            // Execute asynchronous long running transaction here using the model.
            _transactions.TryAdd(transaction.Id, transaction);
    
            // Return response indicating request has been accepted fro processing
            return this.Request.CreateResponse<Transaction>(HttpStatusCode.Accepted, transaction);
                
        }
    
        /// <summary>
        /// Used to retrieve status of a pending transaction.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        public HttpResponseMessage Get(Guid id)
        {
            Transaction transaction = null;
    
            if(!_transactions.TryGetValue(id, out transaction))
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError("Transaction does not exist"));
            }
    
            return this.Request.CreateResponse<Transaction>(HttpStatusCode.OK, transaction);
        }
    }
