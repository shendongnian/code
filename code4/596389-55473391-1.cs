                var serverPath = workspace.GetServerItemForLocalItem(Vars.sLocalPath);
                var serverVersion = new DiffItemVersionedFile(versionControlServer, serverPath, VersionSpec.Latest);
                var localVersion = new DiffItemLocalFile(Vars.sLocalPath, System.Text.Encoding.UTF8.CodePage, DateTime.Now, false);
                try
                {
                    using (var stream = new MemoryStream())
                    using (var writer = new StreamWriter(stream))
                    {
                        var diffOptions = new DiffOptions
                        {
                            Flags = DiffOptionFlags.EnablePreambleHandling,
                            OutputType = DiffOutputType.Unified,
                            TargetEncoding = System.Text.Encoding.UTF8,
                            SourceEncoding = System.Text.Encoding.UTF8,
                            StreamWriter = writer
                        };
                        Difference.DiffFiles(versionControlServer, serverVersion, localVersion, diffOptions, serverPath, true);
                        writer.Flush();
                        diff = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                        if (diff != "")
                        {
                            newutils.WriteLogFile("Vars.enumExitCode.Success");
                            iRtnCode = (int)Vars.enumExitCode.Success;
                            return iRtnCode;
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
