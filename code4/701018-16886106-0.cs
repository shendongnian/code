    if(!String.IsNullOrWhiteSpace(txtIme.Text) && !String.IsNullOrWhiteSpace(txtGodina.Text)....
    {
       // do your work
    }
    
    else
    {
       MessageBox.Show("You didn't fill in all the textboxes!");
       this.Hide();
       new Dodaj().Show();
    }
