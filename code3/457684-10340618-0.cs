    private IEnumerable<SearchItems> GetItems(Guid lastId = new Guid())
    {
        IOrderedQueryable<ItemDescription> items= _itemDescriptionRepository.FindAll().OrderBy(
           c => c.Sort == null).ThenBy(
           c => c.Sort).ThenBy(c => c.Description);
        if(items.Count()==0)
            ModelState.AddModelError("", string.Format("No active {0} entered.", Kids.Resources.Entities.ItemDescription.EntityNamePlural));
 
        return _itemDescriptionRepository.FindAll()
            .OrderBy(c => c.Description).Where(a=>a.IsActive == true || a.ItemDescriptionId == lastId)
            .Select(c => new SearchItems {Text = c.Description, Value = c.ItemDescriptionId.ToString()});
    }
