             public ActionResult Gestion()
             {
                   var viewModel = new FlowViewModel();
                   viewModel.PostesItems = new SelectList(db.Postes.ToList(), "ID_Poste", "ID_Poste"); 
                   return View(viewModel);
             }
