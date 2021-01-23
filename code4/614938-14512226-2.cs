        public virtual ActionResult Create(AddAssetExaminationCommand addAssetExaminationCommand, ICommandHandler<AddAssetExaminationCommand> addExaminationHandler) 
        {
            return ProcessForm(
                addAssetExaminationCommand,
                addExaminationHandler,
                RedirectToAction(MVC.OnboardAsset.Examinations.Create()),
                RedirectToAction(MVC.OnboardAsset.Examinations.Index(addAssetExaminationCommand.AssetId)));
        }
