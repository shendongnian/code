    public class SomeOperation
    {
        private readonly IOrderView _view;
        public SomeOperation(IOrderView view)
        {
            _view = view;
        }
        public void DoSomething(parameters)
        {
            var result = GetMyComplicatedResult();
            _view.ShowResult(result);
        }
    }
