	var tasks = new[]{
			new Task{TaskId = 281, Group = 1, Name = "abc", Order =1},
			new Task{TaskId = 726 , Group = 1, Name = "dre", Order =2},
			new Task{TaskId = 9891, Group = 1, Name = "euf", Order =3},
			new Task{TaskId = 102, Group = 2, Name = "wop", Order =1},
			new Task{TaskId = 44, Group = 2, Name = "wop", Order =2},
			new Task{TaskId = 30, Group = 2, Name = "wop", Order =3},
			new Task{TaskId = 293, Group = 2, Name = "wop", Order =4},
            new Task{TaskId = 295, Group = 3, Name = "was", Order =1},
	};
	
	int[] itemsToRemove = {726, 102, 293};
	
	tasks.Where(task => !itemsToRemove.Contains(task.TaskId))
		 .GroupBy(task => task.Group)
		 .SelectMany(grp => grp.Select((task, grpIndex) => 
                                       { task.Order = grpIndex + 1; return task; }));
