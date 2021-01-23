    reader = new StreamReader("zzz.txt",true);
    
    private void readButton_Click(object sender, EventArgs e)
       {
           while (reader.Peek() != -1)
           {
               label1.Text += reader.ReadLine();
               label2.Text += reader.ReadLine();
               label3.Text += reader.ReadLine();
           }
       }
