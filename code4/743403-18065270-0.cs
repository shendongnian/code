    public ActionResult AddServiceToInvoice(int id, int ser)
        {
            //Use the redirect to action helper and pass the ser variable back
            return RedirectToAction("Index", "Invoice", new{ser = ser});
        }
