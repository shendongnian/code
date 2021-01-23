    void SomeButtonClick(Object sender, EventArgs e)
    {
      ListBox lb = sender as ListBox
      if (lb != null)
      {
        MyListBoxItem item = lb.SelectedItem As MyListBoxItem;
        if (item != Null)
        {
          item.MethodRelatedToButton(); // maybe
        }
      }
    }
