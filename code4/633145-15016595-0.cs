    private void textBox2_Validating(object sender, CancelEventArgs e)
    {
        Regex r = new Regex(@"^\d+.\d{0,1}$");
        if (r.IsMatch(textBox2.Text))
        {
            MessageBox.Show("Okay");
        }
        else
        {
            e.Cancel = true;
            MessageBox.Show("Error");
        }
    }
