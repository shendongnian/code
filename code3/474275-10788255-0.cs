    private void SelectedLV_SelectedIndexChanged(object sender, EventArgs e)
      if (SelectedLV.SelectedIndicies.Count == 0) {
        MoveUpBtn.Enabled = false;
        MoveDownBtn.Enabled = false;
      } else {
        // normal processing
      }
