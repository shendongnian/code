                        //get task:
                        var task = taskService.RootFolder.GetTasks().Where(a => a.Name == "NameOfApplication").FirstOrDefault();
                        try
                        {
                            task.Run();
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error starting task in TaskSheduler with message: " + ex.Message);
                        }
