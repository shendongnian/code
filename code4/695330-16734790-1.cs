        void bu_Click(object sender, EventArgs e)
        {
            Type type = panel1.Controls[(panel1.Controls.IndexOf(sender as Button)) + 1].GetType();
            if(type == typeof(TextBox))
            {
                TextBox tb = (TextBox) panel1.Controls[
                                (panel1.Controls.IndexOf(sender as Button)) + 1];
                tb.Text = "Hello Gagan";
            }
        }
     
