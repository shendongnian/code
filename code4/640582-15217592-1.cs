    private void listBoxControl1_DrawItem(object sender, ListBoxDrawItemEventArgs e)
    {
      if(e.State.HasFlag(DrawItemState.HotLight) )
      {
        e.Appearance.BackColor = Color.Blue;
      }
    }
