        String deletedString = listBox2.Items.ElementAt(listBox2.SelectedIndex).ToString();
        listBox2.Items.RemoveAt(listBox2.SelectedIndex); 
        if(listBox2.Items.RemoveAt(deletedString == "Test"))
        {
         picturebox.Image = null;
        }
