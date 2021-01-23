    if(!string.IsNullOrEmpty(nameTextBox.Text) 
       && !string.IsNullOrEmpty(addressTextBox.Text))
    {
      // here goes your rest of the code
    }
    else
    {
       string pesan = "";
       // no need to check again whether the textbox is empty.
       pesan += "Kolom Nama harus diisi.\n"
       ...
        MessageBox.Show(pesan, "Maaf..", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
