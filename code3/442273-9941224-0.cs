    if (userId == 1) {
      foreach (var item in tabControl.Items) {
        item.Visibility = Visibility.Visible;
    }
    } else if (userId == 0) {
       tabControl.Items[TableControlYouWantVisibile].Visibility = Visibility.Visible;
    }
