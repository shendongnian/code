    using System;
    using System.Data;
    using Microsoft.SqlServer.Dts.Runtime;
    using System.Windows.Forms;
    namespace ST_8eab6a8fbc79431c8c9eb80339c09d1d.csproj
    {
    public class myclass
    {
        int a, b;
        public myclass()
        {
            a = 0;
            b = 0;
        }
    }
    [System.AddIn.AddIn("ScriptMain", Version = "1.0", Publisher = "", Description = "")]
    public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
    {
        #region VSTA generated code
        enum ScriptResults
        {
            Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
            Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
        };
        #endregion
        public void Main()
        {
            Dts.TaskResult = (int)ScriptResults.Success;
            myclass m = new myclass();
            Dts.Variables["myObject"].Value = m;
        }
    }
}
