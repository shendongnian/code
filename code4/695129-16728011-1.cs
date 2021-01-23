    public bool directoryExists2(string directory, string mainDirectory)
            {
                try
                {
                    var list = this.GetFileList(mainDirectory);
                    if (list.Contains(directory))
                        return true;
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
