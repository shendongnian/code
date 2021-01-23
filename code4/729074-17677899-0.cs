            using (TaskService ts = new TaskService())
            {
                var folder = ts.RootFolder.SubFolders.FirstOrDefault(folderItem => folderItem.Name
                        == folderName);
                //folder doesn't exist, we will create it
                if (folder == null)
                {
                    folder = ts.RootFolder.CreateFolder(folderName);
                }
                string xmlTaskData = string.Empty;
                if (File.Exists(fileLocation))
                {
                    xmlTaskData = File.ReadAllText(fileLocation);
                }
                else
                {
                    return false;
                }
                var task = folder.Tasks.FirstOrDefault(taskInFolder => taskInFolder.Name == taskName);
                //doesn't exist, we will add it using default xml
                if (task == null)
                {
                    task = CreateTask(ts, folder, taskName, xmlTaskData);
                }
                if (task != null)
                {
                    // enable/disable the task
                    task.Enabled = add;
                    task.Definition.Settings.Enabled = add;
                    task.RegisterChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
