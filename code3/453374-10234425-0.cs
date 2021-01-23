    using Microsoft.Deployment.WindowsInstaller;
    
    namespace Msi.Tables
    {
        public class PropertyTable
        {
            public static string Get(string msi, string name)
            {
                using (Database db = new Database(msi))
                {
                    return db.ExecuteScalar("SELECT `Value` FROM `Property` WHERE `Property` = '{0}'", name) as string;
                }
            }
            public static void Set(string msi, string name, string value)
            {
                using (Database db = new Database(msi, DatabaseOpenMode.Direct))
                {
                    db.Execute("UPDATE `Property` SET `Value` = '{0}' WHERE `Property` = '{1}'", value, name);
                }
            }
        }
    }
