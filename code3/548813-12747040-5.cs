    DataTable dataTable = new DataTable("SampleDataType"); 
    dataTable.Columns.Add("Id", typeof(Int32)); 
    foreach (var id in <mycollectionofids>)
        dataTable.Rows.Add(id); 
    SqlParameter parameter = new SqlParameter(); 
    parameter.ParameterName="@Id"; 
    parameter.SqlDbType = System.Data.SqlDbType.Structured; 
    parameter.Value = dataTable; 
    command.Parameters.Add(parameter); 
