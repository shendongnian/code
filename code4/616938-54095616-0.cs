            private static string ErrorManager(Exception ex, bool ShowPopUp, bool CrashProgram)
        {
            string stack = ex.StackTrace;
            string source = ex.Source;
            string message = ex.Message;
            string LF = Environment.NewLine;
            string Error = $"A crash happen at {DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss.ff", CultureInfo.InvariantCulture)}{LF}" +
                           $"This is what crashed: {source}{LF}" +
                           $"This is the error message : {LF}{message}{LF + LF}" +
                           $"These are the last instructions executed before the crash : {LF}{stack}{LF + LF}";
            if (ex.InnerException != null)
            {
                Error += $"Inner Exception : {LF}{ex.InnerException.Message}";
            }
            if (ShowPopUp)
            {
                MessageBox.Show(Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (CrashProgram)
            {
                throw new Exception(Error);
            }
            return Error.Trim();
        }
