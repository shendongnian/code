    ...
    foreach (var groupedPeriod in groupedPeriods)
    {
        var cellViewModel = new CellViewModel();
        CellViewModels.Add(cellViewModel);
        foreach (var period in groupedPeriod)
        {
            var rowViewModel = Mapper.Map<RowViewModel>(period); 
            cellViewModel.Rows.Add(rowViewModel);    
        }
    }
    ...
