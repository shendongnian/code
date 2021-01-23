    public class WSData
    {
        public string Value;
        public string Description;
        // First approach: single ctor with dynamic parameter
        public WSData(dynamic source)
        {
            this.Value = source.Value;
            this.Description = source.Description;
        }
 
        // ----- or --------
        // Second approach: one ctor for each class
        public WSData(FirstTypeFromWS source)
        {
            this.Value = source.Value;
            this.Description = source.Description;
        }
        public WSData(SecondTypeFromWS source)
        {
            this.Value = source.Value;
            this.Description = source.Description;
        }
    }
