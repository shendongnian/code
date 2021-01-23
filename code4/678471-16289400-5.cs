		using System.Management; // add reference is required
		using System.Runtime.InteropServices;
		using System.Diagnostics;
		using System.Collections.Generic;
		using System.Linq;
		using System;
		public static partial class NativeMethods {
			[DllImport("kernel32.dll")]
			public static extern bool TerminateThread(
				IntPtr hThread, uint dwExitCode);
			[DllImport("kernel32.dll")]
			public static extern IntPtr OpenThread(
				uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
		}
		public static partial class ProcessThreadExtensions /* public methods */ {
			public static void Abort(this ProcessThread t) {
				NativeMethods.TerminateThread(
					NativeMethods.OpenThread(1, false, (uint)t.Id), 1);
			}
			public static IEnumerable<Process> GetChildProcesses(this Process p) {
				return p.GetProcesses(1);
			}
			public static Process GetParentProcess(this Process p) {
				return p.GetProcesses(-1).SingleOrDefault();
			}
		}
		partial class ProcessThreadExtensions /* non-public methods */ {
			static IEnumerable<Process> GetProcesses(
				this Process p, int direction) {
				return
					from format in new[] { 
						"select {0} from Win32_Process where {1}" }
					let selectName=direction<0?"ParentProcessId":"ProcessId"
					let filterName=direction<0?"ProcessId":"ParentProcessId"
					let filter=String.Format("{0} = {1}", p.Id, filterName)
					let query=String.Format(format, selectName, filter)
					let searcher=new ManagementObjectSearcher("root\\CIMV2", query)
					from ManagementObject x in searcher.Get()
					let process=
						ProcessThreadExtensions.GetProcessById(x[selectName])
					where null!=process
					select process;
			}
			// not a good practice to use generics like this; 
			// but for the convenience .. 
			static Process GetProcessById<T>(T processId) {
				try {
					var id=(int)Convert.ChangeType(processId, typeof(int));
					return Process.GetProcessById(id);
				}
				catch(ArgumentException) {
					return default(Process);
				}
			}
		}
