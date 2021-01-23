    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string file= File.ReadAllText("data.txt");
            FileStream fs = new FileStream("data.txt", FileMode.Append,
            FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            if(file.Contains(textBox1.Text+"\r\n"+textBox2.Text);
            {
               //Do nothing if you already have them in the file
            }
            else
            {
              sw.WriteLine("Email ID: "+textBox1.Text);
              sw.Write("Password: "+textBox2.Text);
              sw.WriteLine();
              sw.WriteLine();
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
            MessageBox.Show("DONE", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
    }
