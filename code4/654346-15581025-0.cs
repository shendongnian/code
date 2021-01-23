        //You need to make a reference to two dlls:
        envdte
        envdte80
        void FormatFiles(List<FileInfo> files)
        {		
      		//If it throws exeption you may want to retry couple more times
			EnvDTE.Solution soln = System.Activator.CreateInstance(Type.GetTypeFromProgID("VisualStudio.Solution.11.0")) as EnvDTE.Solution;
            //try this if you have Visual Studio 2010
			//EnvDTE.Solution soln = System.Activator.CreateInstance(Type.GetTypeFromProgID("VisualStudio.Solution.10.0")) as EnvDTE.Solution;
			soln.DTE.MainWindow.Visible = false;
            EnvDTE80.Solution2 soln2 = soln as EnvDTE80.Solution2;
            //Creating Visual Studio project
            string csTemplatePath = soln2.GetProjectTemplate("ConsoleApplication.zip", "CSharp");
            soln.AddFromTemplate(csTemplatePath, tempPath, "FormattingFiles", false);
            //If it throws exeption you may want to retry couple more times
			Project project = soln.Projects.Item(1);
			
			foreach (FileInfo file in files)
            {
                ProjectItem addedItem;
                bool existingFile = false;
                int _try = 0;
                while (true)
                {            
                    try
                    {
                        string fileName = file.Name;
                        _try++;
                        if (existingFile)
                        {
                            fileName = file.Name.Substring(0, (file.Name.Length - file.Extension.Length) - 1);
                            fileName = fileName + "_" + _try + file.Extension;
                        }
                        addedItem = project.ProjectItems.AddFromTemplate(file.FullName, fileName);
                        existingFile = false;
                        break;
                    }
                    catch(Exception ex)
                    {
                        if (ex.Message.Contains(file.Name) && ex.Message.Contains("already a linked file"))
                        {
                            existingFile = true;
                        }
                    }
                }
                while (true)
                {
					//sometimes formatting file might throw an exception. Thats why I am using loop.
					//usually first time will work
                    try
                    {
                        addedItem.Open(Constants.vsViewKindCode);
                        addedItem.Document.Activate();
                        addedItem.Document.DTE.ExecuteCommand("Edit.FormatDocument");
                        addedItem.SaveAs(file.FullName);
                        break;
                    }
                    catch
                    {
                        //repeat
                    }
                }
            }
			try
            {
                soln.Close();
                soln2.Close();
                soln = null;
                soln2 = null;
            }
            catch
            {
				//for some reason throws exception. Not all the times.
				//if this doesn't closes the solution CleanUp() will take care of this thing
            }
			finally
			{
				CleanUp();
			}
		}	
			
		void CleanUp()
        {
            List<System.Diagnostics.Process> visualStudioProcesses = System.Diagnostics.Process.GetProcesses().Where(p => p.ProcessName.Contains("devenv")).ToList();
            foreach (System.Diagnostics.Process process in visualStudioProcesses)
            {
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                    break;
                }
            }
            tempPath = System.IO.Path.GetTempPath();
            tempPath = tempPath + "\\FormattingFiles";
            new DirectoryInfo(tempPath).Delete(true);
        } 
