        public float ScA { get; set; }        
        public float ScB { get; set; }       
        public float ScG { get; set; }
        public float ScR { get; set; }
        public static Color FromScRgb(float a, float r, float g, float b);
        public static Color FromAValues(float a, float[] values, Uri profileUri);
        public float[] GetNativeColorValues();
        public static Color FromValues(float[] values, Uri profileUri);
