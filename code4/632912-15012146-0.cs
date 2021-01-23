        private void button2_Click(object sender, EventArgs e)  // Read the data...
          {
            StreamReader sr = new StreamReader("f:\\hg.txt");
            textBox1.Text = sr.ReadToEnd().ToString();
            sr.Close();
          
        }
        StreamWriter sw;
        private void button1_Click(object sender, EventArgs e) // write the data in the txt file
        {
                sw = new StreamWriter(textBox2.Text);
               
                sw.WriteLine(textBox3.Text);
                
                sw.Close();
               
            }
