    class test
    {
        private List<Button> buttons;
        
        public test() { /* Whatever constructor logic you need. */ }
        public void setButtons(List<Button> btnsToEnable)
        {
            btnsToEnable.ForEach(btn => btn.Enabled = true);
            // Or perhaps:
            buttons.Intersect(btnsToEnable).ToList().ForEach(btn => btn.Enabled = true);
       }
    }
