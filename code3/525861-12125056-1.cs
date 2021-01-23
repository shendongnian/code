    Contract.Ensures(
        Contract.Result<IEnumerable<MenuItemAction>>() != null &&
        Contract.Result<IEnumerable<MenuItemAction>>().Count() == 
            Contract.Result<IEnumerable<MenuItemAction>>()
               .Select(m => m.Code)
               .Distinct()
               .Count()
    );
