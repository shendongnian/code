    public class MyViewModel : IMyViewModel
    {
        public MyViewModel(IUnityContainer container, IMyModel model)
        {
            _container = container;
            _model = model;
            ...etc...
        }
    }
