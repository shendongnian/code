       private void button6_Click(object sender, EventArgs e)
        {
            string select = (listView1.SelectedItems.Count > 0) ? (listView1.SelectedItems[0].Text) : null;
            if (!string.IsNullOrWhiteSpace(select))
            {
                pths.Remove(select);
                rec.Remove(select);
                string s = String.Join("; ", pths.ToArray());
                string r = String.Join("; ", rec.ToArray());                     
            }
            Disp();
        }
