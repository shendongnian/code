     private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
               
               using (StreamWriter address = new StreamWriter("d:\\addressbook.txt"))//Add correct address
                {
                  address.WriteLine(textBox1.Text + textBox2.Text);
                  //OR
                  address.WriteLine(string.Format("Name:{0}, Email:{1}", textBox1.Text,    textBox2.Text));
                }
            }
            catch (DirectoryNotFoundException exc)
            {
                MessageBox.Show("Directory Could Not Be Found");
            } 
        } 
