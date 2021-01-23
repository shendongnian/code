    using System;
    using System.Security.Permissions;
    using System.Security.Principal;
    public class ImpersonationDemo
    {
	// Test harness. 
	// If you incorporate this code into a DLL, be sure to demand FullTrust.
	[PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
	public static void Main (string[] args)
	{
		try {
			// Check the identity.
			Console.WriteLine ("Before impersonation: " + WindowsIdentity.GetCurrent ().Name);
			// Impersonate a user
			using (WindowsIdentity newId = new WindowsIdentity("Your user name"))
			using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
			{
				// Check the identity.
				Console.WriteLine ("After impersonation: " + WindowsIdentity.GetCurrent ().Name);
			}
				
			// Releasing the context object stops the impersonation 
			// Check the identity.
			Console.WriteLine ("After closing the context: " + WindowsIdentity.GetCurrent ().Name);
		} catch (Exception ex) {
			Console.WriteLine ("Exception occurred. " + ex.Message);
		}
	}
    }
