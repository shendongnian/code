        if (listBox1.SelectedItem != null)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
            }
            listBox2.DisplayMember = "Descripcion";
            listBox2.ValueMember = "Id";
