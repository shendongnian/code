    cmd.Parameters.Add(new OracleParameter(":TRM", Classroom));
    cmd.Parameters.Add(new OracleParameter(":TSALARY", salary)); 
    cmd.Parameters.Add(new OracleParameter(":TTENURE", tenured));
    cmd.Parameters.Add(new OracleParameter(":TPHONE", phone));
    cmd.Parameters.Add(new OracleParameter(":TSSN", SSN));    
   
