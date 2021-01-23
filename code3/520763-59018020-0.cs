    private List<Image> commentColors = new List<Image>();
        private void imgCheckComment_Loaded(object sender, RoutedEventArgs e)
        {
            var si = sender as Image;
            if (si != null)
                commentColors.Add(si);
        }
