    private void button2_Click(object sender, EventArgs e)     
    {    
         if(listbox2.SelectedIndex >= 0)
         {
             string curItem = listBox2.Items[listbox2.SelectedIndex].ToString();
             if(curItem == "SomeOtherString")
             {
                 listBox2.Items.RemoveAt(listBox2.SelectedIndex);      
                 picturebox.Image.Dispose();
                 picturebox.Image = null; // Not really necessary
             }
         }
    } 
