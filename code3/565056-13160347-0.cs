    public class ExpandoViewState : DynamicObject
    {
        private readonly StateBag _viewState;
        public ExpandoViewState(StateBag viewState)
        {
            _viewState = viewState;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _viewState[binder.Name];
            if (result != null)
                return true;
            return base.TryGetMember(binder, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _viewState[binder.Name] = value;
            return true;
        }
    }
    
    ...
    
    dynamic state = new ExpandoViewState(ViewState);
    var val = (string)state.MyProperty;
    state.MyProperty = "hi";
