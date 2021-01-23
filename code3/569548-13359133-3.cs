    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Excel = Microsoft.Office.Interop.Excel;
    using Word = Microsoft.Office.Interop.Word;
    
        /// <summary>
        /// Gets an Interop.Application object and its associated processId
        /// </summary>
        /// <returns>Excel.Application or Word.Application depending on _isExcel</returns>
        private object ApplicationFactory()
        {
        	object application = null;
        	string processName = (_isExcel) ? "excel" : "winword";
        	Process[] beforeProcesses = null;
        	Process[] afterProcesses = null;
        	int i = 0;
        	while (i < 3)
        	{ // ourProcess = afterList - beforeList
        		beforeProcesses = Process.GetProcessesByName(processName);
        		application = (_isExcel) ? (object)new Excel.Application() : (object)new Word.Application();
        		afterProcesses = Process.GetProcessesByName(processName);
        		if ((afterProcesses.Length - beforeProcesses.Length) == 1)
        		{ // OK. Just a single new process
        			break;
        		}
        		else
        		{ // Two or more processes, we cannot get our processId
        			// therefore quit while we can and try again
        			if (_isExcel)
        				((Excel._Application)application).Quit();
        			else
        				((Word._Application)application).Quit();
        			int indexReferences = 1;
        			do
        			{
        				indexReferences = System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
        			}
        			while (indexReferences > 0);
        			application = null;
        			System.Threading.Thread.Sleep(150);
        			i++;
        		}
        	}
        	if (application == null)
        	{
        		throw new ApplicationException("Unable to create Excel Application and get its processId");
        	}
        	List<int> processIdList = new List<int>(afterProcesses.Length);
        	foreach (Process procDesp in afterProcesses)
        	{
        		processIdList.Add(procDesp.Id);
        	}
        	foreach (Process proc in beforeProcesses)
        	{
        		processIdList.Remove(proc.Id);
        	}
        	_processId = processIdList[0];
        	return application;
        }
        
        /// <summary>
        /// Kills _processId process if exists
        /// </summary>
        private void ProcessKill()
        {
        	Process applicationProcess = null;
        	if (_processId != 0)
        	{
        		try
        		{
        			applicationProcess = Process.GetProcessById(_processId);
        			applicationProcess.Kill();
        		}
        		catch
        		{ // no Process with that processId
        		}
        	}
        }
