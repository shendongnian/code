    public sealed class InputDispatch
    {
        private Dictionary<string, IInputHelper> dispatch_ = new Dictionary<string, IInputHelper>(StringComparer.OrdinalIgnoreCase);
        public InputDispatch()
        {
            dispatch_["Websites QA"] = new InputDispatchQA();
            dispatch_["Default"] = new InputDispatch();
        }
        public void Dispatch(string type)
        {
            Debug.Assert(dispatch_.ContainsKey(type));
            dispatch_[type].Navigation();
        }
    }
