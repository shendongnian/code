	public List<SomeObject> AddInformationToSomeObjects(List<SomeObject> someObjects)
	{
		var listOfIDs = someObjects.Select(so => so.ObjectID).ToList();
		var informationToAdd = db.Table
			.Where(t => listOfIDs.Contains(t.ObjectID))
			.Select(t => new { 
								ObjectID = t.ObjectID,
								StringB = t.StringB,
								StringC = t.StringC
							}).ToList();
		
		return(
			from org in someObjects
			join a in informationToAdd on org.ObjectID equals a.ObjectID
			select new SomeObject {
									ObjectID = org.ObjectID,
									StringA = org.StringA,
									StringB = a.StringB,
									StringC = a.StringC
								}).ToList();
	}
