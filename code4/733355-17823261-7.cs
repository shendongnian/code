    			model.Id(m => m.Id);
    			model.Field(m => m.ProjectId).DefaultValue(Model.ProjectId);
    			model.Field(m => m.IsActive).DefaultValue(true);
    		})
    		.Create(create => create.Action("CreateBuilding", "SysMaint"))
    		.Read(read => read.Action("ReadBuildings", "SysMaint", Model))
    		.Update(update => update.Action("UpdateBuilding", "SysMaint"))
    		.Destroy(destroy => destroy.Action("DestroyBuilding", "SysMaint"))
    	)
    )
