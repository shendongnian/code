      listView1.View = View.Details;
      listView1.Columns.Add("People");
      listView1.Columns.Add("Occur");
      while (reader.Read())
      {
          var item = new ListViewItem();
          item.Text = reader["People"].ToString();        // 1st column text
          item.SubItems.Add(reader["Occur"].ToString());  // 2nd column text
          listView1.Items.Add(item);
      }
