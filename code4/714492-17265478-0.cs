        private void button1_Click(object sender, EventArgs e)
        {            
            StreamWriter Info = File.AppendText("Contacts.txt");
    
            for (int i = 0; i < listBox1.Items.Count; i++)
                Info.WriteLine(listBox1.Items[i]);
            Info.Close();
        }
