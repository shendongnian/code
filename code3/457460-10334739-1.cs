    _itemDescriptionRepository.FindAll()
        .OrderBy(c => c.Description)
        .Where(a=>a.IsActive == true || 
            a.ItemDescriptionId == viewModel.ItemDescriptionId) // if viewModel null, this throws
        .Select(c => new SearchItems 
        {
            Text = c.Description, Value = c.ItemDescriptionId.ToString()
        });
