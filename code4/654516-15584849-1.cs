    ...
    if(name != null) {
        sql.Append(" and u.Name = @name");
        cmd.Parameters.AddWithValue("name", name);
    }
    if(dept != null) {
        sql.Append(" and u.Dept = @dept");
        cmd.Parameters.AddWithValue("dept", dept);
    }
    ...
