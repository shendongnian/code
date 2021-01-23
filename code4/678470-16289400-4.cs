		using System.Diagnostics;
		using System.Linq;
		using System;
		class Test {
			public static void Main(string[] args) {
				foreach(var arg in args)
					Console.WriteLine(arg);
			}
			static Test() {
				var current=Process.GetCurrentProcess();
				var parent=current.GetParentProcess();
				var grand=parent.GetParentProcess();
				if(null==grand
					||grand.MainModule.FileName!=current.MainModule.FileName)
					using(var child=Process.Start(
						new ProcessStartInfo {
							FileName=Environment.GetEnvironmentVariable("comspec"),
							Arguments="/c\x20"+Environment.CommandLine,
							RedirectStandardOutput=true,
							UseShellExecute=false
						})) {
						Console.Write(child.StandardOutput.ReadToEnd());
						child.WaitForExit();
						Environment.Exit(child.ExitCode);
					}
		#if false // change to true if child process debugging is needed 
				else {
					if(!Debugger.IsAttached)
						Debugger.Launch();
					Main(Environment.GetCommandLineArgs().Skip(1).ToArray());
					current.Kill(); // or Environment.Exit(0); 
				}
		#endif
			}
		}
