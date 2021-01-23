    // As before until you have your collection.
    // Create simple anonymous objects out of your list items.
    var items = listItemColl.Cast<SPListItem>()
        .Select(li => new {
            Chambers = li["Title"].ToString(),
            Band = li["Band"].ToString(),
            PeopleRecommended = li["PeopleRecommended"].ToString(),
            Band2 = li["Band2"].ToString()});
    // Bind objects to a GridView.
    var gridView = new GridView();
    plhDirRankings.Controls.Add(gridView);
    gridView.DataSource = items;
    gridView.DataBind();
