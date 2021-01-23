    public void Save(VisitEntry visitEntry)
    {
        if (visitEntry.VisitEntryId == Guid.Empty)
        {
            visitEntry.VisitEntryId = Guid.NewGuid();
            visitEntry.DateCreated = DateTime.Now;
            DataContext.VisitEntries.InsertOnSubmit(visitEntry);
        }
        else
        {
            var currentVisitEntry = Get(visitEntry.VisitEntryId);
            if (currentVisitEntry == null) throw RepositoryExceptionFactory.Create("VisitEntry", "VisitEntryId");
            currentVisitEntry.DateModified = DateTime.Now;
            currentVisitEntry.VisitDate = visitEntry.VisitDate;
            currentVisitEntry.VisitType =
                DataContext.VisitTypes.SingleOrDefault(vt => vt.VisitTypeId == visitEntry.VisitTypeId);
            currentVisitEntry.Note = visitEntry.Note;
        }
    }
