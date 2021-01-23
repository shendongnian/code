    public partial class AutosDataContext
        {
            partial void OnCreated()
            {
                this.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            }
        }
