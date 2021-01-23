    var sameRoleNames = from rn in dtNames.AsEnumerable()
                    join rd in dtDetails.AsEnumerable()
                    on new
                    {
                        Name = rn.Field<string>("EmpName"),
                        Role = rn.Field<string>("EmpRole"),
                    } equals new
                    {
                        Name = rd.Field<string>("EmpName"),
                        Role = rd.Field<string>("EmpRole"),
                    }
                    select rd;
    var notSameRoleNames = from rn in dtNames.AsEnumerable()
                       join rd in dtDetails.AsEnumerable()
                       on rn.Field<string>("EmpName") equals rd.Field<string>("EmpName")
                       where rn.Field<string>("EmpRole") != rd.Field<string>("EmpRole")
                       select rd;
    var matchedDataTable = sameRoleNames.CopyToDataTable();
    var unmatchedDataTable = notSameRoleNames.CopyToDataTable();
