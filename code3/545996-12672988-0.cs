    using System;
    using System.Text;
    using System.Diagnostics;
    using System.Security;
    using System.Reflection;
    using System.IO;
    
    namespace ConsoleApplication6 {
    	class Program {
    
    		unsafe static void Main(string[] args) {
    
    			Process process = new Process();
    			String dir = Path.GetDirectoryName(typeof(Program).Assembly.Location);
    			
    			String txtFile = Path.Combine(dir, "example.txt");
    			if (!File.Exists(txtFile)) {
    				StreamWriter sw = File.CreateText(txtFile);
    				sw.Close();
    				sw.Dispose();
    			}
    
    			ProcessStartInfo info = new ProcessStartInfo();
    			
    			info.Domain = "myDomainName";
    			info.UserName = "userName";
    			String pass = "userPassword";
    
    			fixed (char* password = pass) {
    				info.Password = new SecureString(password, pass.Length);
    			}
    
    			// Will be run notepad.exe
    			info.FileName = Environment.ExpandEnvironmentVariables(@"%winDir%\NOTEPAD.EXE");
    			// in notepad.exe will be open example.txt file.
    			info.Arguments = txtFile;
    			info.LoadUserProfile = false;
    			info.UseShellExecute = false;
    			info.WorkingDirectory = dir;
    
    			process.StartInfo = info;
    			process.Start();
    		}
    	}
    }
