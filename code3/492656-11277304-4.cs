            private void GetUserRecommendations()
        {
            var obj = _helper.GetList<Recommendations>(@"http://localhost:1613/Home/GetAllRecommendations");
            _items.Clear();
            foreach (var item in obj)
            {
                _items.Add(item);
            }
            itemListView.ItemsSource = _items;
        }
