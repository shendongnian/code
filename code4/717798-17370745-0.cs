    Audit audit = null;
				List<AuditItem> auditItemsList = new List<AuditItem>();
				List<Audit> totalAudits = new List<Audit>();
				ulong thisId = 0;
				foreach (Tuple<DbAudit, DbAuditItem> tuple in audits)
				{
					if (tuple.Item1.Id == thisId)
					{
						auditItemsList.Add(AuditItemMapper.Map(tuple.Item2));
					}
					else
					{
						if (thisId != 0 && audit != null)
						{
							totalAudits.Add(new Audit(audit.ApplicationToken, audit.AuditKind, audit.DateCreated, audit.ContainerName, audit.ContainerItemId, audit.UserId, auditItemsList));
							auditItemsList.Clear();
						}
						thisId = tuple.Item1.Id;
						audit = (AuditMapper.Map(tuple.Item1));
						auditItemsList.Add(AuditItemMapper.Map(tuple.Item2));
					}
				}
