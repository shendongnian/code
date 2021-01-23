        [HttpPost]
        public ActionResult Edit(SupplierQuoteDto supplierQuoteDto)
        {
            // ........... code
            if (_userContext.EquipmentAction.ClickedAction == ActionType.Create)
                return Json(new { target = "Create" });
            else if (_userContext.EquipmentAction.ClickedAction == ActionType.Edit)
                return Json(new { target = "Edit" });
            else
                return new EmptyResult();
        }
