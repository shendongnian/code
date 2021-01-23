        SortOrder oldOrder = SortOrder.Ascending;
        
        void ChangeSortOrder(SortOrder newOrder)
        {
            if(oldOrder != newOrder)
            {
                list.Values = list.Values.Reverse();
                oldOrder = newOrder;
            }
        }
        
        IEnumerable<Stuff> GetPage(int pageIndex, int numberPerPage)
        {
            return list.Values.Skip(pageIndex * numberPerPage).Take(numberPerPage);
        }
