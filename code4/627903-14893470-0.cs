                    Command psc = new Command("New-Service");
                    psc.Parameters.Add("Name", svcName);
                    psc.Parameters.Add("BinaryPathName", svcExec);
                    psc.Parameters.Add("DisplayName", svcName);
                    psc.Parameters.Add("Description", svcDesc);
                    psc.Parameters.Add("StartupType", "Automatic");
                    WriteVerbose("Verifying service account");
                    if (Account == null) { WriteVerbose("- Using LocalSystem account"); }
                    else { psc.Parameters.Add("Credential", crd); }
                    WriteVerbose("Installing service");
                    Pipeline pipeline = Runspace.DefaultRunspace.CreateNestedPipeline();
                    pipeline.Commands.Add(psc);
                    Collection<PSObject> results = pipeline.Invoke();
