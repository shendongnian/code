    public ActionResult GetValueInput(Guid attributeFieldUid)
    {
        AttributeField field = GetAttributeFieldFromDb(attributeFieldUid);
        AttributeViewModel viewModel = new AttributeViewModel();
        viewModel.FieldType = field.type;
        return View(viewModel);
    }
