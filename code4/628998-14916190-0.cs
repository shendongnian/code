    public class Processor
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ProcessStartInfo MakeProcessStartInfo(string fileName, string arguments)
        {
            return new ProcessStartInfo
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                FileName = fileName,
                Arguments = appArguments
            };
        }
        public void CallExternalApplications()
        {
            try
            {
                var fileName = ConfigurationManager.AppSettings["client_location"];
                using (var process = new Process { StartInfo = MakeProcessStartInfo(fileName, " 1 CLI") })
                {
                    process.Start();
                    if (!process.WaitForExit(1800))
                    {
                        // create a Process here for pskill to kill the "process" using process.Id.
                    }
                }
                using (var process = new Process { StartInfo = MakeProcessStartInfo(fileName, " 2 TIM") })
                {
                    process.Start();
                    if (!process.WaitForExit(1800))
                    {
                        // create a Process here for pskill to kill the "process" using process.Id.
                    }
                }
            }
            catch (Exception e)
            {
                // you really should be using logger.ErrorException(e.Message, e) here
                // and be using the ${exception} layoutrenderer in the layout in the NLog.config file
                logger.Error(e.Message + "\n" + e.StackTrace);
            }
        }
    }
