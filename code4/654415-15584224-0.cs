    var reg = new Registration { name = dto.name }; // less code than with automapper
    reg.Departments = new List<int>(dto.Departments)
        .ConvertAll(input => Context.Departments.Find(input));
    if(reg.Departments.Contains(null)) //a department provided does not exist in the database
        return Request.CreateResponse(HttpStatusCode.BadRequest, "invalid department");
