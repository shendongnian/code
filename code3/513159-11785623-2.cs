    private void MoveToTargetListBox(RadListControl sourceListBox, RadListControl targetListBox)
    {
      try
      {
        if (sourceListBox.Items.Count == 0) { return; }
        if (sourceListBox.SelectedItem == null) { return; }
        RadListDataItem item = sourceListBox.SelectedItem;
        sourceListBox.Items.Remove(item);
        targetListBox.Items.Add(item);
      }
      catch (Exception ex)
      {
        //handle Exception
      }
    }
    private void btnToLeft_Click(object sender, EventArgs e)
    {
      MoveToTargetListBox(lstRight, lstLeft);
    }
    private void btnToRight_Click(object sender, EventArgs e)
    {
      MoveToTargetListBox(lstLeft, lstRight);
    }
