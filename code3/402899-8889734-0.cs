    if (ModelState.IsValid)
        {
            UnitOfWork.RebateLineRepository.Insert(rebateline);
            UnitOfWork.Save();
            return RedirectToAction("Index");  
        }
