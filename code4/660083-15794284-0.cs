    public static string RunScript(string scriptText)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);
            pipeline.Commands.Add("Out-String");
            try
            {
                Collection<PSObject> results = pipeline.Invoke();
                runspace.Close();
                StringBuilder stringBuilder = new StringBuilder();
                if (pipeline.Error.Count > 0)
                {
                    //iterate over Error PipeLine until end
                    while (!pipeline.Error.EndOfPipeline)
                    {
                        //read one PSObject off the pipeline
                        var value = pipeline.Error.Read() as PSObject;
                        if (value != null)
                        {
                            //get the ErrorRecord
                            var r = value.BaseObject as ErrorRecord;
                            if (r != null)
                            {
                                //build whatever kind of message your want
                                stringBuilder.AppendLine(r.InvocationInfo.MyCommand.Name + " : " + r.Exception.Message);
                                stringBuilder.AppendLine(r.InvocationInfo.PositionMessage);
                                stringBuilder.AppendLine(string.Format("+ CategoryInfo: {0}", r.CategoryInfo));
                                stringBuilder.AppendLine(
                                string.Format("+ FullyQualifiedErrorId: {0}", r.FullyQualifiedErrorId));
                            }
                        }
                    }
                }
                else
                    stringBuilder.AppendLine(string.Format("Build is Success"));
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                err = "Build Failed!!!" + "\r\n" + "Check the Setup File Available or Path error";
                return err;
            }
        }
     SCRIPT = "buildmsi.ps1 " + ssource + " " + sdestination;
                projectbuildstatus.Text = RunScript(SCRIPT);
