        private static DateTime findCreationDate(SvnClient client, SvnListEventArgs item)
        {
            Collection<SvnLogEventArgs> logList = new Collection<SvnLogEventArgs>();
            if (item.BasePath != "/" + item.Name)
            {
                client.GetLog(new Uri(item.RepositoryRoot + item.BasePath + "/" + item.Name), out logList);
                foreach (var logItem in logList)
                {
                    foreach (var changed_path in logItem.ChangedPaths)
                    {
                        string filename = Path.GetFileName(changed_path.Path);
                        if (filename == item.Name && changed_path.Action == SvnChangeAction.Add)
                        {
                            return logItem.Time;                            
                        }
                    }
                }
            }
            return new DateTime();
        }
