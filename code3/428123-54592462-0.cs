    private bool CheckSettings()
        {
            var isReset = false;
            string filename = string.Empty;
            try
            {
                var UserConfig = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal);
                filename = UserConfig.FilePath;
                //"userSettings" should be replaced here with the expected label regarding your configuration file
                var userSettingsGroup = UserConfig.SectionGroups.Get("userSettings");
                if (userSettingsGroup != null && userSettingsGroup.IsDeclared == true)
                    filename = null; // No Exception - all is good we should not delete config in Finally block
            }
            catch (System.Configuration.ConfigurationErrorsException ex)
            {
                if (!string.IsNullOrEmpty(ex.Filename))
                {
                    filename = ex.Filename;
                }
                else
                {
                    var innerEx = ex.InnerException as System.Configuration.ConfigurationErrorsException;
                    if (innerEx != null && !string.IsNullOrEmpty(innerEx.Filename))
                    {
                        filename = innerEx.Filename;
                    }
                }
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine("CheckSettings - Argument exception");
            }
            catch (SystemException ex)
            {
                Console.WriteLine("CheckSettings - System exception");
            }
            finally
            { 
                if (!string.IsNullOrEmpty(filename))
                {
                    if (System.IO.File.Exists(filename))
                    {
                        var fileInfo = new System.IO.FileInfo(filename);
                        var watcher
                             = new System.IO.FileSystemWatcher(fileInfo.Directory.FullName, fileInfo.Name);
                        System.IO.File.Delete(filename);
                        isReset = true;
                        if (System.IO.File.Exists(filename))
                        {
                            watcher.WaitForChanged(System.IO.WatcherChangeTypes.Deleted);
                        }
                       
                        try
                        {
                            Properties.Settings.Default.Upgrade();                          
                        } catch(SystemException ex)
                        {
                            Console.WriteLine("CheckSettings - Exception" + ex.Message);
                        }
                    }
                } 
            }
            return isReset;
        }
