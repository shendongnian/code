    public class MyListBox : System.Windows.Forms.ListBox
    {
        private int _selectedIndex = -1;
     
        public MyListBox() : base()
        {
            this.PreviousSelectedIndex = -1;
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }
    
        public int PreviousSelectedIndex { get; set; }
        
        private void OnSelectedIndexChanged(object sender, System.EventArgs e)
        {
            PreviousSelectedIndex = _selectedIndex;
            _selectedIndex = this.SelectedIndex
        }
    }
