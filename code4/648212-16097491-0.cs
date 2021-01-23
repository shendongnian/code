     public override AutomationActionResult Execute(VisitorDataSet.AutomationStatesRow automationStatesRow, Item action, bool isBackgroundThread)
     {
            Visitor visitor = VisitorFactory.GetVisitor();
            string tagValue = visitor.Tags["myTag"]
            //Do stuff
    }
