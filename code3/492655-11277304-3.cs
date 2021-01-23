        private void Button_Click(object sender, RoutedEventArgs e)
    {
      var list = yourListbox.Items;
      var itemCastAsCorrectObjectInstance = (ItemViewModel)list.FirstOrDefault();
      textblock.Text = itemCastAsCorrectObjectInstance.LineOne;
    }
