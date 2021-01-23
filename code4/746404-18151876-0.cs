    void resultList_ItemRealized(object sender, ItemRealizationEventArgs e)
    {
        if (!_viewModel.IsLoading && resultList.ItemsSource != null && resultList.ItemsSource.Count >= _offsetKnob)
        {
            if (e.ItemKind == LongListSelectorItemKind.Item)
            {
                if ((e.Container.Content as TwitterSearchResult).Equals(resultList.ItemsSource[resultList.ItemsSource.Count - _offsetKnob]))
                {
                    _viewModel.LoadPage(_searchTerm, _pageNumber++);
                }
            }
        }
    }
