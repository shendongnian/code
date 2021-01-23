        public Form1()
        {
            InitializeComponent();
            MyDataGridViewInitializationMethod();
        }
        private void MyDataGridViewInitializationMethod()
        {
            gvFactorItems.EditingControlShowing +=
                new DataGridViewEditingControlShowingEventHandler(gvFactorItems_EditingControlShowing);
        }
        private void gvFactorItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress); ;
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit((char)(e.KeyChar)) &&
                e.KeyChar != ((char)(Keys.Enter)) &&
                (e.KeyChar != (char)(Keys.Delete) || e.KeyChar == Char.Parse(".")) &&
                e.KeyChar != (char)(Keys.Back))
            {
                e.Handled = true;
            }
        }
