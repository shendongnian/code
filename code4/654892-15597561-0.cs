    var toolsInUse = TimeLineInit
                        .SelectMany(cycle => cycle.Stage
                        .SelectMany(stage => stage.ToolList.Select(tool => new
    {
        Cycle = cycle,
        Stage = stage,
        Tool = tool.ToolName
    })));
    
    var duplicateUse = toolsInUse.Join(toolsInUse, 
                                        x => x.Tool, 
                                        x => x.Tool, 
                                        (a, b) => new { Use = a, Duplicate = b })
                                    .Where(x => x.Use.Cycle != x.Duplicate.Cycle &&
                                                IsTimeOverLaps(x.Use.Stage.StageSpan, x.Duplicate.Stage.StageSpan));
    
    while (duplicateUse.Count() > 0)
    {
        var item = duplicateUse.First();
    
        Stage ReplaceStage = item.Use.Stage.DeepCopy();//Taking Copy of stage Span to make time shift
        Double TimeDifference = (ReplaceStage.StageSpan.ToTime - ReplaceStage.StageSpan.FromTime).TotalMinutes;//Calculating required time shift
        ReplaceStage.StageSpan.FromTime = item.Duplicate.Stage.StageSpan.ToTime;//FromTime changed accordingly
        ReplaceStage.StageSpan.ToTime = ReplaceStage.StageSpan.ToTime.AddMinutes(TimeDifference);//To Time Changed accordingly
        LCycleTimeShift(item.Use.Cycle, ReplaceStage);//passing refernce
    }
