    [HttpPost]
    public JsonResult AddInvoice(Invoice model)
    {
        int Invoice_Id = CRMServiceDL.insertInvoiceDetail(model);
        int success;
        if (Invoice_Id > 0)
        {
            success = Invoice_Id;
        }
        else
        {
            success = -1;
        }
        return Json(new { success });
    }
