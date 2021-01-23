    private void MouseUp(object sender, MouseEventArgs e) {
      if (DragHasStarted) {
        DealWithDrag();
      }
      else {
        button.PerformClick();
      }
    }
