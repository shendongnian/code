        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var res = (sender as LongListSelector).SelectedItem as LongListData;
            int index = listData.IndexOf(res);
            //mark 1
            var newData = new LongListData() { ImgText = res.ImgText, ImgUrl = new Uri("Images/2.jpg", UriKind.Relative) };
            listData.RemoveAt(index);
            listData.Insert(index, newData);
        }
