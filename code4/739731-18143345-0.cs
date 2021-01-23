      public lEnumerable<TempTable> GetList( int? parentID = null){
      
         foreach ( var item in Context.TempTables
            .Where( x => x.ParentID == parentID )
            .OrderBy( x=> x.SortOrder)
            .ToList() {
            yield return item;
            
            foreach( var child in GetList( item.ID))
            {
                yield return child;
            }
            
         }
      }
      var sortedList = GetList();
