    var result = (from c2 in ((from c1 in context.cases
                               where c1.case_ref.Contains(caseReference)
                               select c1).ToList())
                  select new Case
                  {
                      ID = c2.id,
                      CaseReference = c2.case_ref,
                      Deleted = c2.deleted,
                      Client = (c2.client_id != null ? new MyEntity { ID = c2.client.ID, Name = c2.client.name } : null)
                  }).ToList();
