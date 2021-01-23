    private void btnCATAdd_Click(object sender, EventArgs e)
    {
        Hashtable ht = new Hashtable();
         for(int i=0;i<lbCATallSubcat.Items.Count;i++)
          {
             if(ht.items[i].Selected)
               {
                 ht.Add(lbCATallSubcat.Items[i].Value.ToString(),
                                        lbCATallSubcat.Items[i].Text.ToString());
               }
           }
    
          i = 0;
        foreach (string ent in ht.Values)
        {
           string[] name = new string[lbCATallSubcat.Items.Count];
           for (i = 0; i < lbCATallSubcat.SelectedItems.Count; i++)
           {
               name[i] = lbCATallSubcat.Text;
               this.lbCATSelectedSubcat.Items.Add(name[i]);
           }
           lbCATSelectedSubcat.DisplayMember = ht.Values.ToString();
           lbCATSelectedSubcat.ValueMember = ht.Keys.ToString();
        }
    }
