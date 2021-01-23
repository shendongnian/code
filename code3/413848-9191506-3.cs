    private void Tallenna_Button_Click(object sender, RoutedEventArgs e)
    {
      List<Kurssit> selected = _Kurssit.Where(x => x.IsSelected == true).ToList()
      // You can now operate manipulate this sublist as needed
      // ie. Save this subset of items to IsolatedStorage
      //     Or remove the items from the original _Kurssit collection... whatever :)
    }
