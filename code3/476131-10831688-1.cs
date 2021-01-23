        public static bool ProcessLive(string ExecutablePath)
		{
			try
			{
				
				string strTargetProcessName = System.IO.Path.GetFileNameWithoutExtension(ExecutablePath);
				
				System.Diagnostics.Process[] Processes = System.Diagnostics.Process.GetProcessesByName(strTargetProcessName);
				
				foreach(System.Diagnostics.Process p in Processes)
				{
					foreach(System.Diagnostics.ProcessModule m in p.Modules)
					{
						if(ExecutablePath.ToLower() == m.FileName.ToLower())
							return true;
					}
				}
			}
			catch(Exception){}
			
			return false;
		}
