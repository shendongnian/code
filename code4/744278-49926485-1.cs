    public void ClearTextboxes(Page page) {
      GetAllControls(page)
        .Where(x => typeof(TextBox).IsAssignableFrom(x.GetType()))
        .ToList()
        .ForEach(x => ((TextBox)x).Enabled=false);
    }
