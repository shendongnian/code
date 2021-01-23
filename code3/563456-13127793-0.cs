    static class SerialListner
    {
        public Action<string> SomethingToDisplay;
        void GotSomethingToDisplay(string s)
        {
            SomethingToDisplay(s);
    }
