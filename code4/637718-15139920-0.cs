    class MyCombo : System.Windows.Forms.ComboBox
    {
        public bool ReadOnly { get; set; }
        public int CurrentIndex { get; set; }
        public MyCombo()
        {
            CurrentIndex = -1;
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (ReadOnly && Focused)
                SelectedIndex = CurrentIndex;
            CurrentIndex = SelectedIndex;
            base.OnSelectedIndexChanged(e);
        }
        
    }
