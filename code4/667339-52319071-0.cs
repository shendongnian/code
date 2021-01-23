     Reproduktor rep;
        public Edit(Reproduktor rep)
        {
            InitializeComponent();
            this.rep = rep;
            comboBox1.SelectedIndex = comboBox1.FindStringExact(rep.typSoustavy);
            if (comboBox1.SelectedIndex == 0)
            {
                txtFl.Text = (rep as Reproduktor).fl.ToString(); //+fr
            }
            else if(comboBox1.SelectedIndex ==1)
            {
                txtSub.text blablabla 
            }
            else if(comboBox1 ==2)
            { }
            textBox1.Text = rep.vyrobce;
            textBox2.Text = rep.nazev;
            //cena.tostring
            comboBox1.SelectedIndex = comboBox1.FindStringExact(rep.bluethoot);
        }
        
        private void buttonStorno_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
