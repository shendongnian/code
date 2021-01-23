    using CredentialManagement;
    using System.Diagnostics;
    namespace UnitTestProject1
    {
        [TestClass]
        public class CredentialTests
        {
            [TestMethod]
            public void Set_Credentials_for_older_domain_whe_migration_to_new_domain()
            {
                var accesos = new List<string> {
                "intranet",
                "intranet.xxxxx.net",
                "intranet.zzzzzzzz.com",
                "intranetescritorio.zzzzzzzz.net",
                "more...",
                };
                accesos.ForEach(acceso => SaveCredential(acceso));
            }
            private static Credential SaveCredential(string CredentialName)
            {
                var UserName = @"OLDERDOMAIN\user";
                var Password = "pass";
                var cm = new Credential { Target = CredentialName, Type = CredentialType.DomainPassword };
                if (cm.Exists())
                {
                    cm.Load();
                    Console.WriteLine("Credential " + cm.Target + ". Data: " + cm.Username + " " + cm.Password);
                    //if (cm.Type == CredentialType.Generic)  cm.Delete();
                    return cm;
                }
                cm = new Credential
                {
                    Target = CredentialName,
                    Type = CredentialType.DomainPassword,
                    PersistanceType = PersistanceType.Enterprise,
                    Username = UserName,
                    Password = Password
                };
                cm.Save();
                return cm;
            }
        }
