    using (StreamReader sr = new StreamReader(@"C:\Contacts.txt"))
    {
      while (-1 < sr.Peek())
      {
        try
        {
          string name = sr.ReadLine();
          string email = sr.ReadLine(); 
          var lvi = new ListViewItem(name);
          lvi.SubItems.Add(email);
          listView1.Items.Add(lvi);
        } catch (Exception) { }
      }
      sr.Close();
    }
