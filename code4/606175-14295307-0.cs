    private void button1_Click(object sender, EventArgs e)
    {
        if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
            {
                sw.WriteLine(tB1.Text);
                sw.WriteLine(tB2.Text);
                sw.WriteLine(tB3.Text);
                sw.WriteLine(tB4.Text);
                sw.Close();
            }
                
       }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
            {
                tB1.Text = sr.ReadLine();
                tB2.Text = sr.ReadLine();
                tB3.Text = sr.ReadLine();
                tB4.Text = sr.ReadLine();
                sr.Close();
            }
        }
            
    }
