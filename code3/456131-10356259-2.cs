    using System;
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
    using Microsoft.SqlServer.Dts.Runtime.Wrapper;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;
    /// <summary>
    /// Attempt to use IP script as a source
    /// http://blogs.msdn.com/b/charlie/archive/2009/10/25/hosting-ironpython-in-a-c-4-0-program.aspx
    /// </summary>
    [Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
    public class ScriptMain : UserComponent
    {
        /// <summary>
        /// Create data rows and fill those buckets
        /// </summary>
        public override void CreateNewOutputRows()
        {
            foreach (var item in this.GetData())
            {
                Output0Buffer.AddRow();
                Output0Buffer.Content = item;
            }
        }
        /// <summary>
        /// I've written plenty of code, but I'm quite certain this is some of the ugliest.
        /// There certainly must be more graceful means of 
        /// * feeding your source code to the ironpython run-time than a file
        /// * processing the output of the code the method call
        /// * sucking less at life
        /// </summary>
        /// <returns>A list of strings</returns>
        public List<string> GetData()
        {
            List<string> output = null;
            var ipy = Python.CreateRuntime();
            dynamic test = ipy.UseFile(@"C:\ssisdata\simplePy.py");
            output = new List<string>();
            var pythonData = test.GetIPData();
            foreach (var item in pythonData)
            {
                output.Add(item.ToString());
            }
            return output;
        }
    }
