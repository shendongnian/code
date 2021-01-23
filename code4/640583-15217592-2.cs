    private void listBoxControl1_DrawItem(object sender, ListBoxDrawItemEventArgs e)
    {
      if(e.State != (DrawItemState.Focus & DrawItemState.Selected))
      {
        e.Appearance.BackColor = Color.Blue;
      }
    }
