    [System.AddIn.AddIn("ScriptMain", Version = "1.0", Publisher = "", Description = "")]
    public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
    {
        private static string m_connectionString = @"Data Source=Server Name;
        Initial Catalog=Practice;Integrated Security=True";
       public void Main()
        {
           List<SSISVariable> _coll = new List<SSISVariable>();
            Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
            Package pkg = app.LoadPackage(PackageLocation,Null);
                       Variables pkgVars = pkg.Variables;
            foreach (Variable pkgVar in pkgVars)
            {
                if (pkgVar.Namespace.ToString() == "User")
                {
                    _coll.Add(new SSISVariable ()
                    {
                     Name =pkgVar.Name.ToString(),
                     Val =pkgVar .Value.ToString () 
                    });
               }
            }
            InsertIntoTable(_coll);
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        public void InsertIntoTable(List<SSISVariable> _collDetails)
        {  
           using (SqlConnection conn = new SqlConnection(m_connectionString))
            {
                conn.Open();
                foreach (var item in _collDetails )
                {
                 SqlCommand command = new SqlCommand("Insert into SSISVariables values (@name,@value)", conn);
                 command.Parameters.Add("@name", SqlDbType.VarChar).Value = item.Name ;
                 command.Parameters.Add("@value", SqlDbType.VarChar).Value = item.Val ;
                 command.ExecuteNonQuery();    
                }
            }
         }
      }
       public class SSISVariable
       {
        public string Name { get; set; }
        public string Val { get; set; }
       }
