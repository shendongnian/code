        public int? coalID {get; set;}
        bool isAdd = false;
        public CoalSeamsForm(int? coalId, bool isAdd)
        {
            this.coalID = coalId;
            this.isAdd = isAdd;
            InitializeComponent();
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            Save();
            DataRowView drv = (DataRowView)coalSeamsBindingSource.Current;
            this.coalID = (int)drv["CoalSeamID"];
            this.DialogResult = DialogResult.OK;
        }
