    private void btn_Click(object sender, EventArgs e)// this is the dynamically added button's event which will remove the combobox and textbox
        {
            Button btnh = sender as Button;
            panel1.Controls.OfType<TextBox>().Where(i => i.Tag == sender || i == sender).ToList().ForEach(i => panel1.Controls.Remove(i));
            panel1.Controls.OfType<ComboBox>().Where(i => i.Tag == sender || i == sender).ToList().ForEach(i => panel1.Controls.Remove(i));
            panel1.Controls.Remove(btnh);
        }
