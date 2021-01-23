    #region Namespaces
    using System;
    using System.Data;
    using Microsoft.SqlServer.Dts.Runtime;
    using System.Windows.Forms;
    using System.IO;
    #endregion
    
    namespace ST_f1d7b6ab42e24ad5b5531684ecdcae87
    {
    	[Microsoft.SqlServer.Dts.Tasks.ScriptTask.SSISScriptTaskEntryPointAttribute]
    	public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
    	{
    		public void Main()
    		{
                string filePath = Dts.Variables["User::srcFull"].Value.ToString();
    
                MessageBox.Show(filePath);
    
                Dts.TaskResult = File.Exists(filePath)
                                    ? (int)ScriptResults.Success
                                    : (int)ScriptResults.Failure;
    		}
    
            #region ScriptResults declaration
            enum ScriptResults
            {
                Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
                Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
            };
            #endregion
    	}
    }
