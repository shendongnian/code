    private void ShowResultFlySearch(int direction, string country)
    {
        fly = searchFly.GetFly(direction, country);
        for (int count = 0; count &lt; fly.Count; count++)
        {
            string zbor = fly[0].ToString();
            string companie = fly[1].ToString();
            string aeroport = fly[2].ToString();
            ListViewItem listViewItem = new ListViewItem(zbor);
            listViewItem.SubItems.Add(airport);
            listViewItem.SubItems.Add(companie);
            listView.Items.Add (listViewItem);
        }
    }
