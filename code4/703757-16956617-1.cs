     var view = CollectionViewSource.GetDefaultView(this.MyData);
     view.Filter = ViewFilter;
     view.SortDescriptions.Add(new SortDescription("MyPropertyToSort", ListSortDirection.Descending));
        private bool ViewFilter(object obj)
        {
            var item = obj as MyObject;
            if (item == null)
                return false;
            //your filter logik goes here
            if(item.MyStringProp.StartsWith("Test"))
                return false;
            return true;
           
       }
