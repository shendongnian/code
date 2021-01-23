    private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        using(var customerframe = new CustomerFrame())
        {   
            // I don't know what this line does
            CustomerManager cm = new CustomerManager();
        
            if (customerFrame.ShowDialog() == DialogResult.OK) 
            {
                CustomerFiles.Contact contact = customerframe.GetContact();
                CustomerFiles.Address address = customerframe.GetAddress();
                CustomerFiles.Phone phone = customerframe.GetPhone();
                CustomerFiles.Email email = customerframe.GetEmail();
    
                //Items in my listview
                listviewitem = new ListViewItem();
                listviewitem.SubItems.Add(contact.FirstName);
                listviewitem.SubItems.Add(contact.LastName);
                listviewitem.SubItems.Add(phone.Home);
                listviewitem.SubItems.Add(phone.Mobile);
                listviewitem.SubItems.Add(address.Country);
                listviewitem.SubItems.Add(address.ZipCode);
                listviewitem.SubItems.Add(address.City);
                listviewitem.SubItems.Add(address.Street);
                listviewitem.SubItems.Add(email.Personal);
    
                this.listView1.Items.Add(listviewitem);
            }
        }
    }
