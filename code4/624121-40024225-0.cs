    foreach (ToolBarButton b in toolBar.Buttons)
    {
      //can be negative, for separators, because separators don't have images
      if (b.ImageIndex >= 0)
      {
        Image i = toolBar.ImageList.Images[b.ImageIndex];
        i.Save(b.ImageIndex + ".png");
      }
    }
