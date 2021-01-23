    var matches = from c in CorpSystems
		          join a in AffectedSystems on c.CorpSystemId equals a.CorpSystemId into ac
                  from subSystem in ac.DefaultIfEmpty()
			      where a.TaskItemId == 1
				  select new
			             {
					         c.CorpSystemId,
					         c.SystemName,
					         Assigned = a != null && a.TaskItemId != null
				         };
