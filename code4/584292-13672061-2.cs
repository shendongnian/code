    private void RememberOldValues()
    {
      ArrayList categoryIDList = new ArrayList();
      int index = -1;
      foreach (GridViewRow row in GridView1.Rows)
      {
       index = (int) GridView1.DataKeys[row.RowIndex].Value;
       bool result = ((CheckBox)row.FindControl("CheckBox1")).Checked;
     
      // Check in the Session
      if (Session[CHECKED_ITEMS] != null)
       categoryIDList = (ArrayList)Session[CHECKED_ITEMS];
      if (result)
      {
      if (!categoryIDList.Contains(index))
       categoryIDList.Add(index);
      }
      else
       categoryIDList.Remove(index);
      }
      if (categoryIDList != null && categoryIDList.Count > 0)
       Session[CHECKED_ITEMS] = categoryIDList;
    }
