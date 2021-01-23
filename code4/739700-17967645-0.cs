    class ProductListPresenter {
        private void SetList() {
           _view.SetList(productRepo.GetBindingList());
        }
        
        private void DeleteHandler(Object sender, EventArgs e)
        {
           productRepo.SaveChanges();
           productRepo.DetachLogicallyDeletedEntities();
        }
    }
