                ApplicationClass projectApp = new ApplicationClass();                
                projectApp.FileOpen("C:\\test.mpp", false, Missing.Value, Missing.Value,  Missing.Value,Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,PjPoolOpen.pjPoolReadWrite, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                // Get the active project
                Project proj = projectApp.ActiveProject;
                foreach (Task task in proj.Tasks)
                    {
                                    try
                                    {
                                        Object per = "25";//any data you want to change
                                        task.PhysicalPercentComplete = per;
                                    }
                                    catch
                                    {
                                    }
                    }//foreach
