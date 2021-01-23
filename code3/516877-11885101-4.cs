    [Microsoft.SqlServer.Dts.Tasks.ScriptTask.SSISScriptTaskEntryPointAttribute]
    public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
    {
        /// <summary>
        /// This method is called when this script task executes in the control flow.
        /// Before returning from this method, set the value of Dts.TaskResult to indicate success or failure.
        /// To open Help, press F1.
        /// </summary>
        public void Main()
        {
            int numFiles = Convert.ToInt32(Dts.Variables["numFiles"].Value.ToString());
            switch (numFiles)
            {
                case 0:
                    //MessageBox.Show("Error: No files are in the directory C:\\Directory1\n Please restart execution.");
                    Dts.Events.FireError(0, "File count", "Error: No files are in the directory C:\\Directory1\n Please restart execution.", string.Empty, 0);
                    break;
                case 1:
                    //MessageBox.Show("Error: Only one file was found in the directory C:\\Directory1\n Please restart execution.");
                    Dts.Events.FireError(0, "File count", "Error: Only one file was found in the directory C:\\Directory1\n Please restart execution.", string.Empty, 0);
                    break;
                case 2:
                    //MessageBox.Show("Warning: Only two files have been loaded into the directory C:\\Directory1\n Is this intended?.");
                    Dts.Events.FireWarning(0, "File count", "Warning: Only two files have been loaded into the directory C:\\Directory1\n Is this intended?.", string.Empty, 0);
                    Dts.TaskResult = (int)ScriptResults.Warning;
                    break;
                default:
                    Dts.TaskResult = (int)ScriptResults.Success;
                    break;
            }
        }
        /// <summary>
        /// This enum provides a convenient shorthand within the scope of this class for setting the
        /// result of the script.
        /// 
        /// This code was generated automatically.
        /// </summary>
        enum ScriptResults
        {
            Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
            Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure,
            Warning = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Canceled,
        };
    }
