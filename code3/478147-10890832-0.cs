    using System;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    
    namespace ResolveOverlapIssue
    {
        public partial class Form1 : Form
        {
            private static void DoSomethingElse<T>(ref T Id)
            {
                int i = 00;
            }
    
            public Form1()
            {
                InitializeComponent();
    
                string json = "{" +
                              "UniqueId: 1000000003," +
                              "Id: 3," +
                              "ModifyTimestamp: /Date(1338857699743)/" +
                              "}";
    
                MatchEvaluator matchEvaluator = ConvertJsonDateToDateString;
                var reg = new Regex(@".Date\(\d+\)\/.");
                json = reg.Replace(json, matchEvaluator);
    
            }
    
            public static string ConvertJsonDateToDateString(Match m)
            {
                var dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
                dt = dt.ToLocalTime();
                var result = dt.ToString("yyyy-MM-dd HH:mm:ss");
                return result;
            }
        }
    }
