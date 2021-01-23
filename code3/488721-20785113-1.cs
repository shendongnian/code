    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "M.Naveed")
            {
                textBox1.Text = textBox1.Text + ("Networking");
                textBox2.Text = textBox2.Text + ("Networking");
                textBox1.Text = textBox1.Text + ("mobile");
                textBox2.Text = textBox2.Text + ("mobile");
                ListViewItem li = new ListViewItem("Networking");
                li.SubItems.Add("mobile");
                listView1.Items.Add(li);
            }
            else if (comboBox1.SelectedItem.ToString() == "Zeeshan")
            {
                textBox1.Text = textBox1.Text + ("Networking");
                textBox2.Text = textBox2.Text + ("Networking");
                textBox1.Text = textBox1.Text + ("Jave");
                textBox2.Text = textBox2.Text + ("Jave");
                ListViewItem li = new ListViewItem("Networking");
                li.SubItems.Add("Jave");
                listView1.Items.Add(li);
            }
            else if (comboBox1.SelectedItem.ToString() == "Shamsher")
            {
                textBox1.Text = textBox1.Text + ("Networking"); textBox1.Text = " ";
                textBox2.Text = textBox2.Text + ("Networking");
                textBox1.Text = textBox1.Text + ("Web");
                textBox2.Text = textBox2.Text + ("Web");
                ListViewItem li = new ListViewItem("Networking");
                li.SubItems.Add("Web");
                listView1.Items.Add(li);
            }
            else if (comboBox1.SelectedItem.ToString() == "Mudasir")
            {
                textBox1.Text = textBox1.Text + ("Networking");
                textBox2.Text = textBox2.Text + ("Networking");
                textBox1.Text = textBox1.Text + ("Team Fundation");
                textBox2.Text = textBox2.Text + ("Team Fundation");
                ListViewItem li = new ListViewItem("Networking");
                li.SubItems.Add("Team Funadation");
                listView1.Items.Add(li);
            }
           
            }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Someting");
           
            comboBox1.Items.Add("Mcs");
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("M.Naveed");
            comboBox1.Items.Add ("Mudasir");
            comboBox1.Items.Add ("Zeeshan");
            comboBox1.Items.Add("Shamsher");
        }
        }
    }
