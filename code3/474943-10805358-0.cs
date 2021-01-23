    using StatementsApplication.Models;
    namespace StatementsApplication.Controllers
    {
        public class StatementController : Controller
        {
            public StatementsApplication.Models.IStatementRepository _repo;
            private DALEntities db = new DALEntities();
 
            public StatementController(IStatementRepository repository)
            {
                this._repo = repository;
            }
   
            // additional controller actions here
        }
    }
