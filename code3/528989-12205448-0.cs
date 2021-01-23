    public IEnumerable<Item> GetItemsForPage(int pageNumber)
        {
            return context.Items.Where(x => x.CategoryId == categoryId).
                    OrderByDescending(x => x.CreatedOnDate).
                    Skip(pageNumber * pageSize).  //Note not always 0
                    Take(pageSize);
        }
