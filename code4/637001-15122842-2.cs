    ...
    foreach (var groupedPeriod in groupedPeriods)
    {
        var cellViewModel = new CellViewModel();
        CellViewModels.Add(cellViewModel);
        cellViewModel.Rows = Mapper.Map<List<RowViewMode>>(groupedPeriod);
    }
    ...
