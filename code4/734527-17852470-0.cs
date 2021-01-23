     protected List<string> lst
        {
            get
            {
                List<string> lst =
                    new List<string>();
                lst.Add("1");
                lst.Add("2");
                lst.Add("3");
                return lst;
            }
        }
       private void Form1_Load(object sender, EventArgs e)
        {            
            comboBox1.DataSource = lst;
            comboBox2.DataSource = lst;
        }
       private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst.Contains(comboBox1.SelectedItem.ToString()))
            {
                comboBox2.DataSource = lst.Select(q => q.ToString(CultureInfo.InvariantCulture)).Where(q => q.ToString() != comboBox1.SelectedItem).ToList();
            }
        }
