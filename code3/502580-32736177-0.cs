    using System.IO.Pipes;
    using System.Security.Principal;
    using System.Security.AccessControl;
    [...]
				PipeSecurity lPipeSecurity = new PipeSecurity();
				try
				{
					PipeAccessRule lPar1 = new PipeAccessRule(@"NT AUTHORITY\NETWORK", PipeAccessRights.FullControl, System.Security.AccessControl.AccessControlType.Allow);
					lPipeSecurity.AddAccessRule(lPar1);
				}
				catch (Exception E1)
				{
					Console.WriteLine(PrinterBase.DumpTimestamp(DateTime.UtcNow, true) + ": Exception when trying to give pipe rights to AUTORITY NT NETWORK"+E1.Message);
				}
				try
				{
					System.Security.Principal.SecurityIdentifier lSid = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.BuiltinUsersSid, null);
					PipeAccessRule lPar2 = new PipeAccessRule(lSid, PipeAccessRights.ReadWrite, System.Security.AccessControl.AccessControlType.Allow);
					lPipeSecurity.AddAccessRule(lPar2);
				}
				catch (Exception E2)
				{
					Console.WriteLine(PrinterBase.DumpTimestamp(DateTime.UtcNow, true) + ": Exception when trying to give pipe rights to BuiltInSid "+E2.Message);
				}
				try
				{
					PipeAccessRule lPar3 = new PipeAccessRule(string.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName), PipeAccessRights.FullControl, System.Security.AccessControl.AccessControlType.Allow);
					lPipeSecurity.AddAccessRule(lPar3);
				}
				catch (Exception E3)
				{
					Console.WriteLine(PrinterBase.DumpTimestamp(DateTime.UtcNow, true) + ": Exception when trying to give pipe rights to current user "+E3.Message);
				}
				try
				{
					System.Security.Principal.SecurityIdentifier lSidWorld = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null);
					PipeAccessRule lPar4 = new PipeAccessRule(lSidWorld, PipeAccessRights.ReadWrite, System.Security.AccessControl.AccessControlType.Allow);
					lPipeSecurity.AddAccessRule(lPar4);
				}
				catch (Exception E4)
				{
					Console.WriteLine(PrinterBase.DumpTimestamp(DateTime.UtcNow, true) + ": Exception when trying to give rights to World "+E4.Message);
				}
				try
				{
					System.Security.Principal.SecurityIdentifier lSidLocal = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.LocalSid, null);
					PipeAccessRule lPar5 = new PipeAccessRule(lSidLocal, PipeAccessRights.ReadWrite, System.Security.AccessControl.AccessControlType.Allow);
					lPipeSecurity.AddAccessRule(lPar5);
				}
				catch (Exception E5)
				{
					Console.WriteLine(PrinterBase.DumpTimestamp(DateTime.UtcNow, true) + ": Exception when trying to give rights to Local "+E5.Message);
				}
				lPipeServer = new NamedPipeServerStream(
					lNamedPipe, 
					PipeDirection.InOut, 
					NamedPipeServerStream.MaxAllowedServerInstances, 
					PipeTransmissionMode.Byte, 
					PipeOptions.Asynchronous, 
					0, 
					0, 
					lPipeSecurity);
