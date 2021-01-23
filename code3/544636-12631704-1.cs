    private void showLatestSearches()
    {
        if (fmn.checkLatestSearchesExtistence())
        {
            List<RecentSearchItem> recent = new List<RecentSearchItem>();
            List<String> l = fmn.readLatestSearches();
            for (int i = 0; i <= l.Count-1; i += 1)
            {
                RecentSearchItem r = new RecentSearchItem();
                r.q = l[i];
                r.generalbg = grau;
                r.foreground = blau;
                recent.Add(r);
            }
            recentSearches.ItemsSource = recent;
        }
    }
