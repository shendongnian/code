    [HttpPost]
    public ActionResult MatchLines(SupplierInvoiceMatchingVm viewModel)
    {
        var list = viewModel.Lines;
        // ...
    }
