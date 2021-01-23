      public Form2()
        {
            InitializeComponent();
        }
        private string _originalvalue = null;
        private Form1 _form1;
        /// <summary>
        /// Load values from main form
        /// </summary>
        /// <param name="item"></param>
        public void LoadValues(string item, Form1 form)
        {
            _originalvalue = item;
            _form1 = form;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Do work to change value
            string newvalue = _originalvalue;
            _form1.UpdateItem(newvalue, _originalvalue);
        }
