    public class ParamInfo
    {
        public string LabelText { get; private set; }
        public Type EditControl { get; private set; }
        public Type DataType { get; private set; }
        public object DefaultValue { get; private set; }
        public bool Required { get; private set; }
        //etc. basically a good info class the decides how to draw gui
    }
