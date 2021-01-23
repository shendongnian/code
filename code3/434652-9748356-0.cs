    [Test]
    public void Test1()
    {
        Mapper.CreateMap<Worksheet, WorksheetModelBase>().ConstructUsing(GetWorksheetModel);
        Worksheet entityVisit2 = new Worksheet { VisitLevel = 2 };
        Worksheet entityVisit3 = new Worksheet { VisitLevel = 3 };
        var modelBase1 = Mapper.Map<WorksheetModelBase>(entityVisit2);
        var modelBase2 = Mapper.Map<WorksheetModelBase>(entityVisit3);
        Assert.IsTrue(modelBase1 is V2WorksheetModel);
        Assert.IsTrue(modelBase2 is V3WorksheetModel);
    }
    private WorksheetModelBase GetWorksheetModel(ResolutionContext context)
    {
	    var worksheet = (Worksheet) context.SourceValue;
	    if (worksheet.VisitLevel == 2)
	        return new V2WorksheetModel();
	    if (worksheet.VisitLevel == 3)
	        return new V3WorksheetModel();
	    return new WorksheetModelBase();
    }
