        List<Stuff> ascendingList, descendingList;
        void SetLists()
        {
            ascendingList = list.Values;
            descendingList = list.Values.Reverse().ToList();
        }
        
        IEnumerable<Stuff> GetPage(int pageIndex, int numberPerPage)
        {
            return (order == SortOrder.Ascending ? ascendingList : descendingList).Skip(pageIndex * numberPerPage).Take(numberPerPage);
        }
    
