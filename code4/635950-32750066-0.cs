        public ActionResult GetItemEditForm(EditItemsViewModel editItemsVM)
        {
            if (editItemsVM.SelectedItemID != null)
            {
                //Load the selected item
                ItemsModelManager.GetEditItemsVM(editItemsVM);
                //Clear the submitted form values
                ModelState.Clear();
            }
            return PartialView("_ItemsEditor", editItemsVM);
        }
