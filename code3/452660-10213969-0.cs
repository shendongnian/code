    foreach (Property_Dwelling property in Home)
    {
        //Only displays the messagebox if the address of the property is the same as the text displayed in the listbox
        if(property.GetAddress() == myListBox.Text)
        {
            MessageBox.Show(property.DisplayInfo(), property.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
