     DataTable table = new DataTable();
          
                table.Columns.Add("MODUL", typeof(string));
                table.Columns.Add("ACIKLAMA", typeof(string));
                table.Columns.Add("UZUNLUK", typeof(string));
                table.Columns.Add("GENISLIK", typeof(string));
                table.Columns.Add("MIKTAR", typeof(string));
    
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    table.Rows.Add(listView2.Items[i].SubItems[0].Text, listView2.Items[i].SubItems[1].Text, listView2.Items[i].SubItems[2].Text, listView2.Items[i].SubItems[3].Text, listView2.Items[i].SubItems[4].Text);
                } //Which Subitems you want to add in the listview
