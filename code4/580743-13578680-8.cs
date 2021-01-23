    private void RePopulateValues()
    {
      ArrayList categoryIDList = (ArrayList)Session[CHECKED_ITEMS];
      if (categoryIDList != null && categoryIDList.Count > 0)
      {
      foreach (GridViewRow row in GridView1.Rows)
      {
       int index = (int)GridView1.DataKeys[row.RowIndex].Value;
      if (categoryIDList.Contains(index))
      {
       CheckBox myCheckBox = (CheckBox) row.FindControl("CheckBox1");
       myCheckBox.Checked = true;
      }
      }
      }
    }
