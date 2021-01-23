        SortOrder oldOrder = SortOrder.Ascending;
        
        void SetSortOrder(SortOrder newOrder)
        {
            if(oldOrder != newOrder)
            {
                list.Values = list.Values.Reverse().ToList();
                oldOrder = newOrder;
            }
        }
        
        IEnumerable<Stuff> GetPage(int pageIndex, int numberPerPage, SortOrder order)
        {
            SetSortOrder(order);
            return list.Values.Skip(pageIndex * numberPerPage).Take(numberPerPage);
        }
