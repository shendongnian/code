    var matches = from c in CorpSystems
		          join a in AffectedSystems on c.CorpSystemId equals a.CorpSystemId into ac
                  from subSystem in ac.DefaultIfEmpty()
				  select new
			             {
					         c.CorpSystemId,
					         c.SystemName,
					         Assigned = subSystem != null && subSystem.TaskItemId != null
				         };
