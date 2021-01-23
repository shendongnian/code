    @{
          //create your first model
          HomeModel CModel = new HomeModel();
          CModel.ChemistryDataPull(Model.SearchValue);
    
          //create your other model
          PartialSlagViewModel DModel = new PartialSlagViewModel();
          DModel.SlagViewDataPull(Model.SearchValue); 
    }
    
    @Html.Partial("PartialAnalysis", CModel)
    @Html.Partial("PartialSlag", DModel)
