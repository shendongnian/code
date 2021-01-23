    for (int i = 0; i < rOrderItems.Items.Count; i++) {
      CheckBox chk = (CheckBox)rOrderItems.Items[i].FindControl("cbxRemove");
      if (chk.Checked) {
        //remove this item
      }
    }
