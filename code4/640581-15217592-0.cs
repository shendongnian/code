    private void listBoxControl1_DrawItem(object sender, ListBoxDrawItemEventArgs e)
    {
      if(e.State == DrawItemState.HotLight)
      {
        e.Appearance.BackColor = Color.Blue;
      }
    }
