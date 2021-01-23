    public class AClassWhatever
    {
        public AClassWhatever()
        {
            this.DoAThingToAString = this.DoAThingToAStringImpl;
        }
        public Func<string, string> DoAThingToAString { get; set; }
        protected virtual string DoAThingToAStringImpl(string input)
        {
            return input + input + " fill my eyes.";
        }
    }
