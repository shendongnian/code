    using (var customerFrame = new CustomerFrame()) {
      if (customerFrame.ShowDialog() == DialogResult.OK) {
        Contact contact = customerFrame.GetContact();
        listviewitem = new ListViewItem(contact.FirstName);
        listviewitem.SubItems.Add(contact.LastName);
        // etc.
        this.listView1.Items.Add(listviewitem);
      }
    }
