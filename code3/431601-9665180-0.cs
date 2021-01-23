    class ParameterNames
    {
        public string Length { get; private set; }
        public string Height { get; private set; }
        public string Width { get; private set; }
    
        public ParameterNames(string className)
        {
            Length = "length_" + className;
            Height = "height_" + className;
            Width = "width_" + className;
        }
    }
