    private void Button_MouseLeave(object sender, MouseEventArgs e) {
      if (backButtonContextMenu.IsMouseOver)
        return;
      backButtonContextMenu.IsOpen = false;
      Debug.WriteLine("MouseLeave called");
    }
