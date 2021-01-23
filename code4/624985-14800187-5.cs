    using System;
    using System.Data;
    using Microsoft.SqlServer.Dts.Runtime;
    using System.Windows.Forms;
    using System.Net;
    
    namespace ST_5fa66fe26d20480e8e3258a8fbd16683.csproj
    {
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
                try
                {
                    string symbol = Dts.Variables["User::Symbol"].Value.ToString();
                    DateTime startDate = Convert.ToDateTime(Dts.Variables["User::StartDate"].Value);
                    DateTime endDate = Convert.ToDateTime(Dts.Variables["User::EndDate"].Value);
                    string resolution = Dts.Variables["User::Resolution"].Value.ToString();
                    string urlYahooChart = Dts.Variables["User::URLYahooChart"].Value.ToString();
    
                    string rootFolder = Dts.Variables["User::RootFolder"].Value.ToString();;
                    string fileExtension = Dts.Variables["User::FileExtension"].Value.ToString();
                    string fileName = Dts.Variables["User::FileName"].Value.ToString();
                    string downloadPath = Dts.Variables["User::FilePath"].Value.ToString();
    
                    if (!System.IO.Directory.Exists(rootFolder))
                        System.IO.Directory.CreateDirectory(rootFolder);
    
                    urlYahooChart = string.Format(urlYahooChart
                                            , symbol
                                            , startDate.Month
                                            , startDate.Day
                                            , startDate.Year
                                            , endDate.Month
                                            , endDate.Day
                                            , endDate.Year
                                            , resolution);
    
                    bool refire = false;
                    Dts.Events.FireInformation(0, string.Format("Download URL of {0}", symbol), urlYahooChart, string.Empty, 0, ref refire);
    
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(urlYahooChart, downloadPath);
    
                    Dts.TaskResult = (int)ScriptResults.Success;
                }
                catch (Exception ex)
                {
                    Dts.Events.FireError(0, "Download error", ex.ToString(), string.Empty, 0);
                }
            }
        }
    }
