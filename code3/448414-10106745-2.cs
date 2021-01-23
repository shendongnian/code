    var matches = from c in CorpSystems
		          join a in AffectedSystems on c.CorpSystemId equals a.CorpSystemId into ac
                  from subSystem in ac.DefaultIfEmpty()
			      where subSystem == null || subSystem.TaskItemId == 1
				  select new
			             {
					         c.CorpSystemId,
					         c.SystemName,
					         Assigned = subSystem != null && subSystem.TaskItemId != null
				         };
