        enum GameExitCodes
        {
            Normal=0,
            UnknownError=-1,
            OutOfMemory=-2
        }
        //Game Application
        static void Main(string[] args)
        {
            try
            {
                // Start game
                Environment.ExitCode = (int)GameExitCodes.Normal;
            }
            catch (OutOfMemoryException)
            {
                Environment.ExitCode = (int)GameExitCodes.OutOfMemory;
            }
            catch (Exception)
            {
                Environment.ExitCode = (int)GameExitCodes.UnknownError;
            }
        }
