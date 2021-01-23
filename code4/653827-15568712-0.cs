	using System;
	using System.Diagnostics;
	namespace ConsoleApplication1 {
		class Program {
			static void StartProcess(string Path) {
				Process Process = Process.Start(Path);
				Process.EnableRaisingEvents = true;
				Process.Exited += (sender, e) => {
					StartProcess(Path);
				};
			}
			static void Main(string[] args) {
				for (int i = 0; i < 2; i++) {
					StartProcess("notepad");
				}
				Console.ReadLine();
			}
		}
	}
