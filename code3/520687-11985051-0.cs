    var milestones = ReadOnlySession.All<Milestone>()
    	.Where(x => x.InstructionID == instructionid)
    	.OrderBy(x => x.Name)
    	.Select(x => new { 
    		Milestone = x,
    		TotalClosedTasks = ReadOnlySession.All<InstructionTask>()
    								.Count(c => c.Milestone == x.MilestoneID && !c.IsOpen)
    		TotalOpenTasks = ReadOnlySession.All<InstructionTask>()
    								.Count(c => c.Milestone == x.MilestoneID && c.IsOpen)
    	})
    	.AsEnumerable()
    	.Select(x => new Milestone {
    		Name = x.Milestone.Name,
    		InstructionID = x.Milestone.InstructionID,
    		Body = x.Milestone.Body,
    		Deadline = x.Milestone.Deadline,
    		MilestoneID = x.Milestone.MilestoneID,
    		TotalClosedTasks = x.TotalClosedTasks,
    		TotalOpenTasks = x.TotalOpenTask
    	})
    	.ToList();
