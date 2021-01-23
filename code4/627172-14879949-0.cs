    public class BusinessContainer : WindsorContainer
    {
        public BusinessContainer()
        {
            RegisterComponents();
        }
        
        private void RegisterComponents()
        {
            // Presenters
            AddComponentWithLifestyle("HelloWorld.presenter", typeof(HelloWorldPresenter), LifestyleType.Transient);
        }
    }
    }
