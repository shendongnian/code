    //Seleciton options, with single selection
    PromptSelectionOptions Options = new PromptSelectionOptions();
    Options.SingleOnly = true;
    Options.SinglePickInSpace = true;
    //This is the filter for blockreferences
    SelectionFilter Filter = new SelectionFilter(new TypedValue[] { new TypedValue(0, "INSERT") });
    //calls the user selection
    PromptSelectionResult Selection = Document.Editor.GetSelection(Options, Filter);
    if (Selection.Status == PromptStatus.OK)
    {
        using (Transaction Trans = Document.Database.TransactionManager.StartTransaction())
        {
            //This line returns the selected items
           AcadBlockReference SelectedRef = (AcadBlockReference)(Trans.GetObject(Selection.Value.OfType<SelectedObject>().First().ObjectId, OpenMode.ForRead).AcadObject);
        }
    }
