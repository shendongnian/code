    var results = (from csr in _context.project_sprint_resource
                   join pr in _context.project_resource
                       on csr.ProjectResourceId equals pr.Id
                   join prpa in _context.project_resource_person_allocation
                       on pr.Id equals prpa.ProjectResourceId into sub
                   from subq in sub.DefaultIfEmpty()
                   where csr.ProjectSprintId == sprintId
                   select new { csr = csr, pr = pr, subq = subq}).AsEnumerable(x => 
                       select new SprintResourceDto
                           {
                               SprintId = x.csr.ProjectSprintId,
                               ProductiveHours = x.pr.ExpectedProductiveHours,
                               ProjectResourceId = x.pr.Id,
                               AssignedHours = x.pr.ExpectedProductiveHours,
                               ResourceTypeId = x.pr.ResourceTypeId,
                               PersonId = x.subq != null ? x.subq.PersonId : (int?)null,
                               ResourceStartDate = pr.StartDate,
                               ResourceEndDate = x.pr.EndDate,
                               Deleted = x.csr.Deleted.HasValue,
                               ResourceType = new ReferenceTypeDto
                                   {
                                       Description = x.pr.resource_type.Description,
                                       Id = x.pr.resource_type.Id
                                   },
                               Person = x.subq != null ? new PersonDto
                                   {
                                       Id = x.subq.Id,
                                       Firstname x.subq.person.Firstname
                                       Surname = subq.person.Surname
                                   } : null
                           });
        return results.ToList();
    }
    catch (Exception e)
    {
        var ne = e; // What on earth is this by the way?
        return null;
    }
