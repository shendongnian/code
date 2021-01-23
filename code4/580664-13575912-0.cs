        readonly BindingSource _bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            _bindingSource.DataSource = new List<Associate>();
            dataGridAssociates.DataSource = _bindingSource;
        }
        public class Associate
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string assocRFID { get; set; }
            public int assocID { get; set; }
            public bool canDoDiverts { get; set; }
            public bool canDoMHE { get; set; }
            public bool canDoLoading { get; set; }
        }
        private void buttonAddAssoc_Click(object sender, EventArgs e)
        {
            //First & Last name splitter
            string allValue = textBoxAssocName.Text;
            string firstNameTemp = String.Empty;
            string lastNameTemp = String.Empty;
            int getIndexOfSpace = allValue.IndexOf(' ');
            for (int i = 0; i < allValue.Length; i++)
            {
                if (i < getIndexOfSpace)
                {
                    firstNameTemp += allValue[i];
                }
                else if (i > getIndexOfSpace)
                {
                    lastNameTemp += allValue[i];
                }
            }
            firstNameTemp = firstNameTemp.Trim(); // To remove empty spaces
            lastNameTemp = lastNameTemp.Trim(); // To Remove Empty spaces
            //End splitter
            int assocIDTemp; //TryParse succeeds
            bool assocIDparse; //Bool for TryParse
            //Try Parsing Associate ID to an integer
            //Includes catch -> return
            assocIDparse = int.TryParse(textBoxAssocID.Text, out assocIDTemp);
            if (assocIDparse == false)
            {
                MessageBox.Show("Please use only numbers in the AssocID input");
                return;
            }
            var obj = (Associate) _bindingSource.AddNew();
            if (obj != null)
            {
                obj.firstName = firstNameTemp;
                obj.lastName = lastNameTemp;
                obj.assocID = assocIDTemp;
                obj.canDoDiverts = checkBoxDiverts.Checked;
                obj.canDoMHE = checkBoxMHE.Checked;
                obj.canDoLoading = checkBoxLoading.Checked;
            }
            textBoxAssocID.Clear();
            textBoxAssocName.Clear();
            textBoxRFID.Clear();
            
        }
