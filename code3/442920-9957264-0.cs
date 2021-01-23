    public enum MethodType
    {
        None,
        Show,
        Hide,
        Validate
    }
    var methods = new Dictionary<MethodType, Action<Panel, String, List<EventActions>>();
    methods.Add(MethodType.Show, show);
    methods.Add(MethodType.Hide, hide);
    methods.Add(MethodType.Validate, validate);
