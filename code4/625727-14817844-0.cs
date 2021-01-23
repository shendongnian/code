    void Button1Click(object sender, EventArgs e)
    {
          try{
               if(!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(richTextBox1.Text))
               {
                    if(radioButton1.Checked)
            // BAD idea to have hard-coded path, even worse it's in user's folder; copied from OP
                         path = @"C:\Users\M.Waqas\Desktop\Saver\Saver\Files\"; 
        
        // Would be better if SaveFileDialog was used...        
                         path = System.IO.Path.Combine(path, textBox1.Text  ".txt");
                
                         richTextBox1.SaveFile(path); // THERE IS THIS METHOD ALREADY
                    } else
                         MessageBox.Show("No data");
          } catch (Exception x){
               MessageBox.Show("Error: "+x);
          }
    }
