        [HttpGet]
        public ActionResult Edit(int CycleModelID)
        {
            CycleModel cycleModel = unitOfWork_CycleModel.GenericTEntityRepository.GetByID(CycleModelID);
            //ViewBag.CycleType = new SelectList(unitOfWork_cycleType.GenericTEntityRepository.Get(orderBy: CycleTypes => CycleTypes.OrderBy(CycleType => CycleType.Type)), "CycleTypeID", "Type", cycleModel.CycleTypeID);
            ViewBag.CycleType = new SelectList(unitOfWork_cycleType.GenericTEntityRepository.Get(orderBy: CycleTypes => CycleTypes.OrderBy(CycleType => CycleType.Type)), "CycleTypeID", "Type");
            return View(cycleModel);
        }
        [HttpPost]
        public ActionResult Edit(CycleModel  _CycleModel)
        {
            if (ModelState.IsValid)
            {
                unitOfWork_CycleModel.GenericTEntityRepository.Update(_CycleModel);
                unitOfWork_CycleModel.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CycleType = new SelectList(unitOfWork_cycleType.GenericTEntityRepository.Get(orderBy: CycleTypes => CycleTypes.OrderBy(CycleType => CycleType.Type)), "CycleTypeID", "Type");
            return View(_CycleModel);
        }
