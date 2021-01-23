    public ActionResult Index()
    {
        // in your question you have shown something called innerArray, so I assume you
        // already retrieved this from your database or something:
        SomeDomainModel[,] innerArray = ...
    
        var model = new List<RowViewModel>();
        for (var row = 0; row < innerArray.GetUpperBound(0); row++)
        {
            var rowModel = new RowViewModel
            {
                Columns = new List<ColViewModel>()
            };
            for (var col = 0; col < innerArray.GetUpperBound(1); col++)
            {
                rowModel.Columns.Add(new ColViewModel
                {
                    RowNumber = innerArray[row, col].RowNo,
                    ColumnNumber = innerArray[row, col].ColumnNo,
                    QuestionText = innerArray[row, col].Question,
                    FieldValue = innerArray[row, col].FieldValue,
                });
            }
            model.Add(rowModel);
        }
    
        return View(model);
    }
    
    [HttpPost]
    public ActionResult Index(List<RowViewModel> model)
    {
        ...
    }
