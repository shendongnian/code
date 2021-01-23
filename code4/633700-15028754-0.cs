            try
            {
                double days = double.Parse(textBox1.Text);
                label1.Text = DateTime.Now.AddDays(days).ToLongDateString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "error"); }
