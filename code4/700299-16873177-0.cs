      positiveItems = items.SelectMany(x => x.SubItem).Where(x=> x.ID == 1).Select(x=>x.Item);
      //items still IQueryable , so we can concat it with another IQueryable
      negativeItems = items.SelectMany(x=>x.SubItem).Where(x=>x.ID != 1).Select(x=>x.Item);
      //just an using option
      allItems = positiveItems.Concat(negativeItems);
