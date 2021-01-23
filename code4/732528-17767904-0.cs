    if (data.StartsWith("S08"))
        {
            try
            {
                textBox1.Text = data.Substring(4).Trim();
                timer3.Stop();
                scan();
                timer3.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            comport.DiscardInBuffer();
        }
        else if (data.StartsWith("S144"))
        {
