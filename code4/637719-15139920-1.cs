    class MyCombo : System.Windows.Forms.ComboBox
    {
        public bool ReadOnly { get; set; }
        public int currentIndex;
        public MyCombo()
        {
            currentIndex = SelectedIndex ;
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (ReadOnly && Focused)
                SelectedIndex = currentIndex;
            currentIndex = SelectedIndex;
            base.OnSelectedIndexChanged(e);
        }
        
    }
