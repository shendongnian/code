    class MyModel
    {
        IList<string> UnactivatedHeaders { get; set; }
        IList<int> UnactivatedPanels { get; set; }
        public MyModel
        {
            UnactivatedHeaders = new List<string>();
            UnactivatedPanels = new List<int>();
        }
    }
