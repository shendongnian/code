    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    namespace myPlugins
    {
        public class ADImport : Plugin
        {
            //I defined these outside my method so I can call a Finalizer before unloading the appDomain 
            private PrincipalContext AD = null; 
            private PrincipalSearcher ps = null;
            private DirectoryEntry _LDAP = null; //used to get underlying LDAP properties for a user
            private MDBDataContext _db = null; //used to connect to a SQL server, also uses unmanaged resources
            public override GronkIT()
            {
                using (AD = new PrincipalContext(ContextType.Domain,"my.domain.com"))
                {
                    UserPrincipal u = new UserPrincipal(AD);
                    u.Enabled=true;
                    using(ps = new PrincipalSearcher(u))
                    {
                        foreach(UserPrincipal result in ps.FindAll())
                        {
                            using (result)
                            {
                                _LDAP = (DirectoryEntry)result.GetUnderlyingObject();
                                //do stuff with result
                                //do stuff with _LDAP
                                result.Dispose(); //even though I am using a using block, if I do not explicitly call Dispose, it's never disposed of
                                _LDAP.Dispose(); //even though I am using a using block, if I do not explicitly call Dispose, it's never disposed of
                            }
                        }
                    }
                }
            }
            public override JustGronkIT()
            {
                using(_db = new MDBDataContext("myconnectstring"))
                {
                    //do stuff with SQL
                    //Note that I am using a using block and connections to SQL are properly disposed of when the using block ends
                }
            }
            ~ADImport()
            {
                AD.Dispose(); //This works, does not throw an exception
                AD = null;
                ps.Dispose(); //This works, does not throw an exception
                ps = null;
                _LDAP.Dispose(); //This works, does not throw an exception
                _LDAP = null;
                _db.Dispose(); //This throws an exception saying that you can not call Dispose on an already disposed of object
            }
        }
    }
