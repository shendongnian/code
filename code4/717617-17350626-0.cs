    public partial class SelectFromListUserControl : UserControl
    {
        public class SelectedItemEventArgs : EventArgs
        {
            public string SelectedChoice { get; set; }
        }
        
        public event EventHandler<SelectedItemEventArgs> ItemHasBeenSelected;
        
        public SelectFromListUserControl()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            var handler = ItemHasBeenSelected;
            if (handler != null)
            {
                handler(this, new SelectedItemEventArgs 
                    { SelectedChoice = listBox1.SelectedItem.ToString() });
            }
        }
    }
