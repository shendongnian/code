    var trash = new ItemList<TrashContainerItem>(N2.Find.RootItem.Children, new TypeFilter(typeof(TrashContainerItem))).FirstOrDefault();
    if (trash != null)
    {
      var detailToPermDelete = new ItemList<TargetDetailModel>(trash.Children, new TypeFilter(typeof(TargetDetailModel)));
      for (int permDeleteCount = 0; permDeleteCount < detailToPermDelete.Count; permDeleteCount++)
      {                            
        N2.Context.Current.Persister.Delete(detailToPermDelete.ElementAt(permDeleteCount));
      }
    }
