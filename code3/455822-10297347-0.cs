    using System.Data; 
    using System.Data.SqlClient; 
    
    class dd 
    { 
    static void Main() 
    { 
            SqlConnection cn=new SqlConnection("server=.\SqlExpress;uid=sa;pwd=tiger;database=employeemaster"); 
            SqlDataAdapter da=new SqlDataAdapter("select no,name from employee",cn); 
            DataTable dt=new DataTable(); 
            da.Fill(dt); 
            //emp has 2 columns known as no and name. 
            //Initialize the SqlCommandBuilder. 
            SqlCommandBuilder cd=new SqlComandBuilder(da); 
            //create a DataRow 
            DataRow dr=dt.NewRow(); 
            dr["no"]=101; 
            dr["name"]="romil"; 
            //the row is temporarily saved 
            dt.Rows.Add(dr); 
            //save the Row permanently in database
 
               da.Update(dt); 
        }
    }
