     public IEnumerable<TempTable> PrepareList(IEnumerable<TempTable> list){
         foreach(var item in list.OrderBy( x=> x.SortOrder) ){
             yield return item;
             foreach(var child in PrepareList(item.ChildTempTables)){
                 yield return child;
             }
         }
     }
     // since EF will automatically fill each children on fetch
     // all we need is just a top level nodes
     // which we will pass to PrepareList method
     var list = Context.TempTables.ToList().Where(x=> x.ParentID == null);
     var sortedList = PrepareList(list).ToList();
     // it is good to create list at the end if you are going to 
     // iterate it many times and logic will not change.
     
