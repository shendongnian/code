    list1.FullOuterJoin(
        list2, 
        list1Item => list1Item.Id,
        list2Item => list2Item.Id,
        (list1Item, list2Item) => {
          if(listItem1!=null && listItem2!=null)
          {
            return merge(listItem1, listItem2);
          }
          return listItem1 ?? listItem2;
        })
