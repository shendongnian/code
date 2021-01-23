            List<string> names = new List<string>();
            names.Add("name1");
            names.Add("name2");
            names.Add("name3");
            names.Add("name4");
            names.Add("name5");
            comboBox1.Items.Clear();
            foreach (string name in names)
            {
                comboBox1.Items.Add(name);
            }
            comboBox1.SelectedIndex = 0; //selects first item
