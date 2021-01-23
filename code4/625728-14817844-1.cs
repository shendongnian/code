    void Button1Click(object sender, EventArgs e)
    {
          try{
               if(!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(richTextBox1.Text))
               {
                    if(radioButton1.Checked) 
                         path = @"C:\Users\M.Waqas\Desktop\Saver\Saver\Files\"; 
            
                    path = System.IO.Path.Combine(path, textBox1.Text  ".txt");
                
                    richTextBox1.SaveFile(path);  
                
               } else
                    MessageBox.Show("No data");
          } catch (Exception x){
               MessageBox.Show("Error: "+x);
          }
    }
