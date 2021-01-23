    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NHSession : ActionFilterAttribute
    {
        public NHSession()
        {
            Order = 100;
        }
    
        protected ISessionFactory sessionFactory
        {
            get
            {
                    return MvcApplication.SessionFactory;
            }
        }
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = sessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
            session.BeginTransaction();
        }
    
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var session = CurrentSessionContext.Unbind(sessionFactory);
            if (session != null)
            {
                if (session.Transaction.IsActive)
                {
                    try
                    {
                        session.Transaction.Commit();
                    }
                    catch
                    {
                        session.Transaction.Rollback();
                    }
                }
                session.Close();
            }
        }
    }
