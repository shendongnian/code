    teams = context
      .Teams
      .Include("TeamDepartments")
      .Include("TeamEmployees")
      .Select(t => new // notice this is an anonymous object
          {
              sourceSystemId = t.TeamId,
              name = t.Name,
              manager = t.EmployeeIdTeamManager,
              teamLead = t.EmployeeIdTeamLead,
              employees = t.TeamEmployees.Select(te => te.EmployeeId),
              departments = t.TeamDepartments.Select(td => td.DepartmentId)
           })
      .ToList() // first run the query on the server without the ToArray calls
      .Select(obj => new TeamDto
          {     // then project the in-memory results onto your DTO.
              sourceSystemId = obj.sourceSystemId,
              name = obj.name,
              manager = obj.manager,
              teamLead = obj.teamLead,
              employees = obj.employees.ToArray(),
              departments = obj.departments.ToArray()
          })
      .ToList();
