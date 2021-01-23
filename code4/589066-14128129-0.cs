    SqlConnection conn = new SqlConnection("Server=ax12d;Database=DemoDataAx;Trusted_Connection=True;");
    
    SqlCommand cmd = new SqlCommand(@"Select Level2 as Category 
                                      from Mtq_RetailHierarchy 
                                      Where Level1 IN (SELECT Department 
                                                       From @Depts)", conn);
    
    cmd.Parameters.Clear();
    SqlParameter param cmd.Parameters.AddWithValue("@Depts", _Depts);
    param.SqlDbType = SqlDbType.Structured;
    param.TypeName = "dbo.Departments"; //This can either be a table or a User Defined Type
    
    
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataTable SelectedCatsData = new DataTable();
    da.Fill(SelectedCatsData);
    return SelectedCatsData;
