    [HttpPost]
    public JsonResult AddInvoice(Invoice model)
    {
        int invoiceId = CRMServiceDL.insertInvoiceDetail(model);
        int success = invoiceId > 0 ? invoiceId : -1;
        return Json(new { success });
    }
