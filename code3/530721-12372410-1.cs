        private void BtnAddNewServiceClick(object sender, EventArgs e)
        {            
            Presenter.ShowDialog<ServerRolesControl, AddNewServiceForm, ServiceModel, Role>(this, new AddNewServiceForm(), SetAddedRolesLabel);
        }
        private void BtnViewAllServicesClick(object sender, EventArgs e)
        {
            Presenter.ShowDialog<ServerRolesControl, ViewRolesForm, ServiceModel, Role>(this, new ViewRolesForm(), SetDeletedRolesLabel);
        }
