    private void ShowForm(int a, string b, double c)
    {
            Form2 frm = new Form2();
            frm.SomeTextBox.Tag = a;
            frm.SomeTextBox2.Tag = b;
            frm.SomeTextBox3.Tag = c;
            frm.ShowDialog();
    } 
