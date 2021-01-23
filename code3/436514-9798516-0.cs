    public interface IAction
    {    
        void Execute();
    }
    public abstract class Action<T> : IAction, IDisposable where T : Action<T>
    {
        public void Execute()
        {
            try
            {
                //Start unit of work  by your unit of work pattern or
                transaction.Begin();
                OnExecute();
                //End Unit of work
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
        protected abstract void OnExecute();
        public void Dispose()
        {
           
        }
    }
    public class MyBusinessLogig : Action<MyBusinessLogig>
    {
        protected override void OnExecute()
        {
           //Implementation
        }
    }
    public class MyAnotherBusinessLogic : Action<MyAnotherBusinessLogic>
    {
        protected override void OnExecute()
        {
            //Nested transaction
            MyBusinessLogig logic = new MyBusinessLogig();
            logic.Execute();
        }
    }
