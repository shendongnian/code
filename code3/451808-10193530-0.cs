        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
                comboBox1.Items.Add(i.ToString());
            comboBox1.Text = comboBox1.Items[0].ToString();
        }
        bool needtoupdate = true;
        public class CheckedItems
        {
            public CheckedItems()
            {
                for (int i = 0; i < b.Length; i++)
                {
                    b[i] = false;
                }
            }
            public bool[] b = { false, false, false, false };
        }
        CheckedItems[] allcheckeditems = { new CheckedItems(), new CheckedItems(), new CheckedItems()};
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            needtoupdate = false;
            checkBox1.Checked = allcheckeditems[Convert.ToInt32(comboBox1.Text)].b[0];
            checkBox2.Checked = allcheckeditems[Convert.ToInt32(comboBox1.Text)].b[1];
            checkBox3.Checked = allcheckeditems[Convert.ToInt32(comboBox1.Text)].b[2];
            checkBox4.Checked = allcheckeditems[Convert.ToInt32(comboBox1.Text)].b[3];
            needtoupdate = true;
        }
        void saveallchecked()
        {
            if (!needtoupdate) return;
            allcheckeditems[Convert.ToInt32(comboBox1.Text)].b[0] = checkBox1.Checked;
            allcheckeditems[Convert.ToInt32(comboBox1.Text)].b[1] = checkBox2.Checked;
            allcheckeditems[Convert.ToInt32(comboBox1.Text)].b[2] = checkBox3.Checked;
            allcheckeditems[Convert.ToInt32(comboBox1.Text)].b[3] = checkBox4.Checked;
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            saveallchecked();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            saveallchecked();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            saveallchecked();
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            saveallchecked();
        }
