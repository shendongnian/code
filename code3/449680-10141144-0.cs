    public partial class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.SelectionChangeCommitted += this.OnComboBoxSelectionChangeCommitted;
            this.Enter += this.OnControlEnter;
            this.LostFocus += this.OnComboBoxLostFocus;
        }
        
        private void OnControlEnter(object sender, EventArgs e)
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void OnComboBoxLostFocus(object sender, EventArgs e)
        {
            this.DropDownStyle = ComboBoxStyle.Simple;
        }
        private void OnComboBoxSelectionChangeCommitted(object sender, EventArgs e)
        {
            // Notify to update other controls that depend on the combo box value
        }
    }
