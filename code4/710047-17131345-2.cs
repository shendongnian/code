    class Accum
    {
        private int sum, count;
    
        //public event AverageChanged; 
        public void Add(int value)
        {
           sum += value;
           count += 1;
           if (count >= 100)
           {
               OnAvarerageChanged(sum/count);
               sum = 0;
               count = 0;
           }
        }
        public Label MyLabel { get; set; }
        private void OnAvarerageChanged(int av)
        {
            SetTextCallback d = new SetTextCallback(SetText);
            string text = av.ToString();
            MyLabel.BeginInvoke(d, new object[] { text });
        }
        private void SetText(string text)
        {
            this.MyLabel.Text = text;
        }
    }
