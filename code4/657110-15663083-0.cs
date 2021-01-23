    public static class ApplicationSettings
    {
        public static Double MarginInner { get; private set; }
        public static Double MarginOuter { get; private set; }
        public static Double StrokeThickness { get; private set; }
        static ApplicationSettings()
        {
            MarginInner = 6D;
            MarginOuter = 10D;
            StrokeThickness = 3D;
        }
    }
