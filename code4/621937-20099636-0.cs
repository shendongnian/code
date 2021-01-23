    using System;
    using System.DirectoryServices.AccountManagement;
    
    namespace WebAdminTest
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
				var user = new System.Security.Principal.NTAccount(@"IIS APPPOOL\10e6c294-9836-44a9-af54-207385846ebf");
				var sid = user.Translate(typeof (System.Security.Principal.SecurityIdentifier));
				var ctx = new PrincipalContext(ContextType.Machine);
				// This is weird - the user SID resolves to a group prinicpal, but it works that way.
				var appPoolIdentityGroupPrincipal = GroupPrincipal.FindByIdentity(ctx, IdentityType.Sid, sid.Value);
				Console.WriteLine(appPoolIdentityGroupPrincipal.Name);
				Console.WriteLine(appPoolIdentityGroupPrincipal.DisplayName);
				GroupPrincipal targetGroupPrincipal = GroupPrincipal.FindByIdentity(ctx, "Performance Monitor Users");
				// Making appPoolIdentity "group" a member of the "Performance Monitor Users Group"
				targetGroupPrincipal.Members.Add(appPoolIdentityGroupPrincipal);
				targetGroupPrincipal.Save();
				Console.WriteLine("DONE!");
				Console.ReadKey();
    		}
    	}
    }
	
