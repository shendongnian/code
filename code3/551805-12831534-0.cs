    [HttpPost]
    [ValidateInput(false)]
    public ActionResult Create(VisitViewModel viewModel, Guid[] associatedCasesSelected, Guid[] selectedParties)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Time = _timeEntryHelper.Value;
            AddLookupsToViewModel(viewModel);
            return View(viewModel);
        }
        var visitEntry = Mapper.Map<VisitViewModel, VisitEntry>(viewModel);
        visitEntry.VisitDate = _timeEntryHelper.AddTimeToDate(visitEntry.VisitDate);
        visitEntry.UserId = _currentUser.UserId;
        visitEntry.OfficeId = _currentUser.OfficeId;
        try
        {
            _visitEntryService.Create(visitEntry, associatedCasesSelected, selectedParties);
            this.FlashInfo(string.Format(Message.ConfirmationMessageCreate, Resources.Entities.Visit.EntityName));
            DataContext.SubmitChanges();
        }
        catch (RulesException ex)
        {
            ex.CopyTo(ModelState);
        }
        if (ModelState.IsValid)
            return RedirectToAction("Edit", "Case", new { caseId = viewModel.CaseId });
        AddLookupsToViewModel(viewModel);
        return View(viewModel);
    }
