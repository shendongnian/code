    private void button1_Click(object sender, EventArgs e)
    {
        using(StreamWriter sw = new StreamWriter(PathFile))
        {
             sw.WriteLine(textBox1.Text);
        }
        // No really needed to call close
    }
