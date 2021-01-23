    DateTime dt;
    string Temp1 = "Your Date";
    if (DateTime.TryParse(Temp1, out dt))
    {
         cmd.Parameters.Add(new SqlParameter("@logDateTime", dt)); 
    }
    else
         cmd.Parameters.Add(new SqlParameter("@logDateTime", DateTime.Now)); 
