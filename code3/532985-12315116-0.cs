    public interface IMyInterface
    {
        void OnItemClicked();
        void OnItemHover();
        void OnItemDoubleClicked();
    }
    public class MyNewClass : IMyInterface
    {
        private IMyInterface _target;
        public MyNewClass(IMyInterface target)
        {
            _target = target;
        }
        public void OnItemClicked()
        {
            // custom functionality
        }
        public void OnItemHover()
        {
            _target.OnItemHover();
        }
        public void OnItemDoubleClicked()
        {
            _target.OnItemDoubleClicked();
        }
    }
