    public class ChildViewModel : PropertyChangedBase, IChild
    {
        // IChild members...
    
        public ChildViewModel Configure(IScreen parent)
        {
            Parent = parent;
            return this;
        }
    }
    
    public class ParentViewModel : Screen
    {
        public ChildViewModel Child { get; set; }
    
        protected override void OnInitialize()
        {
            Child = _viewModelFactory.Create<ChildViewModel>()
                                     .Configure(this);
        }
    }
