    var groupItems =
        webservice.Where(i => i.GroupName != null)
                  .GroupBy(i => i.GroupName)
                  .Select(grp => new { Group=grp.Key,Items=grp.ToList()});
    foreach (var groupItem in groupItems)
        Console.WriteLine("Groupname: {0} Items: {1}"
            , groupItem.Group
            , string.Join(",", groupItem.Items.Select(i => i.ItemName)));
