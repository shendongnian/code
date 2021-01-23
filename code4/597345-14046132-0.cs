    public List<SelectListItem> GetBookPrices()
    {
        var Books = ddlEntity.tblBook.ToList();
        var BookPrice = Books.Select(bookPrice => new SelectListItem
                                                 {
                                                  Text = Convert.ToString(bookPrice .Price),
                                                  Value = Convert.ToString(bookPrice.Price)
                                                 }).Distinct();
        return BookPrice.ToList();
    }
