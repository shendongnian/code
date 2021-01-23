			var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
			var matchingProcesses = System.Diagnostics.Process.GetProcesses().Where(x => x.Id != currentProcess.Id && x.ProcessName == currentProcess.ProcessName);
			foreach (var process in matchingProcesses) {
				process.Kill();
			}
