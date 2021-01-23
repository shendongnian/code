        if (pipeline.Error != null && pipeline.Error.Count > 0)
                    {
                        StringBuilder pipelineError = new StringBuilder();
                        pipelineError.AppendFormat("Error calling Add-MailboxPermission.");
                        foreach (object item in thisPipeline.Error.ReadToEnd())
                        {
                            pipelineError.AppendFormat("{0}\n", item.ToString());
                        }
                        ErrorText = ErrorText + "Error: " + pipelineError.ToString() + Environment.NewLine;
                    }
