    DateTime? myfield
    if (null==myfield)
    {
     var nullableparam = new OdbcParameter("@myfield", DBNull.Value);
     nullableparam.IsNullable = true;
     nullableparam.OdbcType = OdbcType.DateTime;
     nullableparam.Direction = ParameterDirection.Input;
     cm.Parameters.Add(nullableparam);
    }
    else
    {
     cm.Parameters.AddwithValue("@myfield",myfield);
    }
