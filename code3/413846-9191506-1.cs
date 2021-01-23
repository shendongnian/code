    private void Tallenna_Button_Click(object sender, RoutedEventArgs e)
    {
      List<Kurssit> selected = _Kurssit.Where(x => x.IsSelected == true).ToList()
      // You can now operate manipulate this sublist as needed
      // ie. remove the items from the _Kurssit collection, or what have you
    }
