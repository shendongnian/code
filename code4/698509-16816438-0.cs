    [HttpPost]
    public ActionResult MatchLines([Bind(Prefix="Lines")] IEnumerable<SupplierInvoiceMatchingDto> list)
    {
        ...
    }
