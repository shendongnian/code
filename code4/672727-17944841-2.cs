    protected void moveRight_Click(object sender, EventArgs e)
       {
       for (int i = 0; i < lbFirst.Items.Count; i++)
       {
       if (lbFirst.Items[i].Selected)
       {
       lbSecond.Items.Add(lbFirst.Items[i]);
       lbFirst.Items.Remove(lbFirst.Items[i]);
       }
       }
       }
