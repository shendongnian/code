    return db.Reports.Select(r => new {
        Project = r.ProjectId;
        Location = r.Location.LocationId;
        Department = r.Department.DepartmentId;
        Person = r.Person.Email;
        StatusCode = r.StatusCode.StatusId;
        Description: r.Description
        RoundTrip: r.RoundTrip
        IsBillable: r.IsBillable,
        StartDate: r.StartDate,
        EndDate: r.EndDate
        TimeUpdated: r.TimeUpdated
    });
    // Or if you're using HttpResponseMessage
    return Request.CreateResponse(HttpStatusCode.Ok, 
        db.Reports.Select(r => new {
            Project = r.ProjectId;
            Location = r.Location.LocationId;
            Department = r.Department.DepartmentId;
            Person = r.Person.Email;
            StatusCode = r.StatusCode.StatusId;
            Description: r.Description
            RoundTrip: r.RoundTrip
            IsBillable: r.IsBillable,
            StartDate: r.StartDate,
            EndDate: r.EndDate
            TimeUpdated: r.TimeUpdated
        }));
