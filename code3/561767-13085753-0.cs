    class ModelA 
    {
        bool TestValue{get;set;}
    }
    class ViewModelA<ModelA>
    {
        ValueViewModel<bool> TestValue{get; private set;}
        public ViewModelA(ModelA model) 
        {
            base.Model = model;
            this.Initialize();
        }
    }
    class ModelB 
    {
        string Username;
    }
    class ViewModelB<ModelB>
    {
        ValueViewModel<string> Username{get; private set;}
        public ViewModelB(ModelB model) 
        {
            base.Model = model;
            this.Initialize();
        }
    }
