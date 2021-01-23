     /// <summary>
        /// This contains the logic for constructing and submitting a report 
        /// request to the Google Apps reporting service and reading the response.
        ///
        /// The description of the web service protocol can be found at:
        ///
        /// http://code.google.com/apis/apps/reporting/google_apps_reporting_api.html
        /// 
        /// Example usage:
        /// Get the latest accounts report to standard output.
        ///   client.getReport("accounts", null, null);
        /// Get the accounts report for May 15, 2007 and save it to out.txt.
        ///   client.getReport("accounts", "2007-05-15", "out.txt");
        /// </summary>
        public class ReportsManager
        {
            /// <summary>
            /// URL to POST to obtain an authentication token
            /// </summary>
            private const string CLIENT_LOGIN_URL =
              "https://www.google.com/accounts/ClientLogin";
    
            /// <summary>
            /// URL to POST to retrive resports from the API 
            /// </summary>
            private const string REPORTING_URL =
              "https://www.google.com/hosted/services/v1.0/reports/ReportingData";
    
            /// <summary>
            /// Date format of the API
            /// </summary>
            private const string DATE_FORMAT = "yyyy-MM-dd";
    
            /// <summary>
            /// Hour of the day when the API data gets published
            /// </summary>
            private const int PUBLISH_HOUR_OF_DAY = 13; // Publish hour + 1 hour;
    
            /// <summary>
            /// Time diference to UTC
            /// </summary>
            private const int PUBLISH_TIME_DIFERENCE_TO_UTC = -8;
    
            /// <summary>
            /// Email command-line argument
            /// </summary>
            private const string EMAIL_ARG = "email";
    
            /// <summary>
            /// Password command-line argument
            /// </summary>
            private const string PASSWORD_ARG = "password";
    
            /// <summary>
            /// Domain command-line argument
            /// </summary>
            private const string DOMAIN_ARG = "domain";
    
            /// <summary>
            /// Report command-line argument
            /// </summary>
            private const string REPORT_ARG = "report";
    
            /// <summary>
            /// Date command-line argument
            /// </summary>
            private const string DATE_ARG = "date";
    
            /// <summary>
            /// Output File command-line argument
            /// </summary>
            private const string OUT_FILE_ARG = "out";
    
            /// <summary>
            /// Message for command-line usage
            /// </summary>
            private const string USAGE = "Usage:  " +
              "ReportingAPI --" + EMAIL_ARG + " <email> --" +
              PASSWORD_ARG + " <password> [ --" +
              DOMAIN_ARG + " <domain> ] --" +
              REPORT_ARG + " <report name> [ --" +
              DATE_ARG + " <YYYY-MM-DD> ] [ --" +
              OUT_FILE_ARG + " <file name> ]";
    
            /// <summary>
            /// List of command-line arguments
            /// </summary>
            private static string[] PROPERTY_NAMES = new String[] {EMAIL_ARG,
              PASSWORD_ARG, DOMAIN_ARG, REPORT_ARG, DATE_ARG, OUT_FILE_ARG};
    
            /// <summary>
            /// List of required command-line arguments
            /// </summary>
            private static string[] REQUIRED_PROPERTY_NAMES = new String[] {
              EMAIL_ARG, PASSWORD_ARG, REPORT_ARG};
    
            /// <summary>
            /// Google Apps Domain
            /// </summary>
            public string domain = null;
    
            /// <summary>
            /// Email address of an Administrator account
            /// </summary>
            public string email = null;
    
            /// <summary>
            /// Password of the Administrator account
            /// </summary>
            public string password = null;
    
            /// <summary>
            /// Identifies the type of account
            /// </summary>
            private string accountType = "HOSTED";
    
            /// <summary>
            /// Identifies the Google service
            /// </summary>
            private string service = "apps";
    
            /// <summary>
            /// Contains a token value that Google uses to authorize 
            /// access to the requested report data
            /// </summary>
            private string token = null;
    
            /// <summary>
            /// Default constructor
            /// </summary>
            public ReportsManager(string username, string password, string domain)
            {
                this.email = username + "@" + domain;
                this.password = password;
                this.domain = domain;
            }
    
            /// <summary>
            /// Retrieves the Authentication Token
            /// </summary>
            /// <returns>Returns the authentication token.</returns>
            public string GetToken()
            {
                return this.token;
            }
    
            /// <summary>
            /// Logs in the user and initializes the Token
            /// </summary>
            public void ClientLogin()
            {
                string token = null;
                UTF8Encoding encoding = new UTF8Encoding();
                string postData = "Email=" + System.Web.HttpUtility.UrlEncode(this.email) +
                  "&Passwd=" + System.Web.HttpUtility.UrlEncode(this.password) +
                  "&accountType=" + System.Web.HttpUtility.UrlEncode(this.accountType) +
                  "&service=" + System.Web.HttpUtility.UrlEncode(this.service);
                byte[] data = encoding.GetBytes(postData);
                HttpWebRequest request =
                  (HttpWebRequest)WebRequest.Create(CLIENT_LOGIN_URL);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                Stream inputStream = request.GetRequestStream();
                inputStream.Write(data, 0, data.Length);
                inputStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseStr = (new StreamReader(
                  response.GetResponseStream())).ReadToEnd();
                char[] tokenizer = { '\r', '\n' };
                string[] parts = responseStr.Split(tokenizer);
                foreach (string part in parts)
                {
                    if (part.StartsWith("SID="))
                    {
                        token = part.Substring(4);
                        break;
                    }
                }
                this.token = token;
            }
    
            /// <summary>
            /// Creates a XML request for the Report
            /// </summary>
            /// <param name="reportName">The name of the Report: activity, 
            ///   disk_space, email_clients, quota_limit_accounts, 
            ///   summary, suspended_account</param>
            /// <param name="date">Date of the Report</param>
            /// <returns>Thx XML request as a string</returns>
            public string createRequestXML(string reportName, string date)
            {
                if (this.domain == null)
                {
                    this.domain = getAdminEmailDomain();
                }
                string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                xml += "<rest xmlns=\"google:accounts:rest:protocol\"";
                xml += " xmlns:xsi=\"";
                xml += "http://www.w3.org/2001/XMLSchema-instance\">";
                xml += "<type>Report</type>";
                xml += "<token>" + this.GetToken() + "</token>";
                xml += "<domain>" + this.domain + "</domain>";
                xml += "<date>" + date + "</date>";
                xml += "<reportType>daily</reportType>";
                xml += "<reportName>" + reportName + "</reportName>";
                xml += "</rest>";
                return xml;
            }
    
            /// <summary>
            /// Get the domain of the admin's email address.
            /// </summary>
            /// <returns>the domain, otherwise returns null</returns>
            public string getAdminEmailDomain()
            {
                if (this.email != null)
                {
                    int atIndex = this.email.IndexOf('@');
                    if (atIndex > 0 && atIndex + 1 < this.email.Length)
                    {
                        return this.email.Substring(atIndex + 1);
                    }
                }
                else
                {
                    throw new ArgumentNullException("Invalid Email");
                }
                return null;
            }
    
            public enum ReportType
            {
                accounts,
                activity,
                disk_space,
                email_clients,
                quota_limit_accounts,
                summary,
                suspended_account
            }
    
            /// <summary>
            /// Get the reports by reportName for a Date, and writes the report
            /// at filename         /// or to the console if filename is null.
            /// </summary>
            /// <param name="reportName">The name of the Report: activity, 
            ///   disk_space, email_clients, quota_limit_accounts,summary,
            ///   suspended_account</param>
            /// <param name="date">Date of the Report, 
            ///   null date gets latest date available</param>
            private Dictionary<string, ArrayList> getReport(string reportName, string date)
            {
                if (date == null)
                {
                    date = getLatestReportDate().ToString(DATE_FORMAT);
                }
                else
                {
                    try
                    {
                        date = System.Convert.ToDateTime(date).ToString
                          (DATE_FORMAT);
                    }
                    catch
                    {
                        throw new ArgumentException("Invalid Date");
                    }
                }
                string xml = createRequestXML(reportName, date);
                HttpWebRequest request =
                  (HttpWebRequest)WebRequest.Create(REPORTING_URL);
                request.Method = "POST";
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] postBuffer = encoding.GetBytes(xml);
                request.ContentLength = postBuffer.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postBuffer, 0, postBuffer.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(
                  response.GetResponseStream());
                String firstLine = null;
                String lineBuffer = String.Empty;
                if (reader.Peek() >= 0)
                {
                    firstLine = reader.ReadLine();
                    checkError(firstLine, reader);
                }
    
                Dictionary<string, ArrayList> csv = new Dictionary<string, ArrayList>();
                string[] headers = null;
                if (firstLine != null)
                {
                    headers = firstLine.Split(',');
                    foreach (string header in headers)
                    {
                        csv.Add(header, new ArrayList());
                    }
                }
                if (headers != null)
                {
                    while ((lineBuffer = reader.ReadLine()) != null)
                    {
                        string[] dataLine = lineBuffer.Split(',');
                        for (int i = 0; i < csv.Keys.Count; i++)
                        {
                            csv[headers[i]].Add(dataLine[i]);
                        }
                    }
                }
                reader.Close();
                return csv;
            }
    
            /// <summary>
            /// Get the reports by reportName for a Date, and writes the report 
            /// at filename or to the console if filename is null.
            /// </summary>
            /// <param name="reportName">The name of the Report: activity, 
            ///   disk_space, email_clients, quota_limit_accounts,summary,
            ///   suspended_account</param>
            /// <param name="date">
            ///   Date of the Report, null date gets latest date available</param>
            public Dictionary<string, ArrayList> getReport(ReportType reportType, DateTime date)
            {
                string reportName = Enum.GetName(typeof(ReportType), reportType);
                return this.getReport(reportName, date.ToString(DATE_FORMAT));
            }
    
            /// <summary>
            /// Checks for errors on the Http Response, errors are on XML format.
            /// When the response is xml throws an Exception with the xml text.
            /// </summary>
            /// <param name="firstLine">
            ///   First line of the StreamReader from the Http Response</param>
            /// <param name="reader">StreamReader from the Http Response</param>
            private void checkError(string firstLine, StreamReader reader)
            {
                if (firstLine.Trim().StartsWith("<?xml"))
                {
                    String xmlText = firstLine;
                    while (reader.Peek() >= 0)
                    {
                        xmlText += reader.ReadLine();
                    }
                    throw new Exception(xmlText);
                }
            }
    
            /// <summary>
            /// Get latest available report date, 
            /// based on report service time zone.
            /// Reports for the current date are available after 12:00 PST8PDT 
            /// the following day.
            /// </summary>
            /// <returns>Lastest date available</returns>
            public DateTime getLatestReportDate()
            {
                if (DateTime.UtcNow.AddHours(PUBLISH_TIME_DIFERENCE_TO_UTC).Hour
                  < PUBLISH_HOUR_OF_DAY)
                {
                    return DateTime.Now.AddDays(-2);
                }
                else
                {
                    return DateTime.Now.AddDays(-1);
                }
            }
    
            /// <summary>
            /// Gets the properties from the command-line arguments.
            /// </summary>
            /// <param name="args">command-line arguments</param>
            /// <returns>Properties Hashtable</returns>
            private static Hashtable getProperties(string[] args)
            {
                Hashtable properties = new Hashtable();
                for (int i = 0; i < args.Length; i++)
                {
                    bool found = false;
                    for (int j = 0; j < PROPERTY_NAMES.Length; j++)
                    {
                        if (args[i].Equals("--" + PROPERTY_NAMES[j]))
                        {
                            found = true;
                            if (i + 1 < args.Length)
                            {
                                properties.Add(PROPERTY_NAMES[j], args[i + 1]);
                                i++;
                                break;
                            }
                            else
                            {
                                throw new ArgumentException("Missing value for " +
                                  "command-line parameter " + args[i]);
                            }
                        }
                    }
                    if (!found)
                    {
                        throw new ArgumentException(
                          "Unrecognized parameter " + args[i]);
                    }
                }
                for (int i = 0; i < REQUIRED_PROPERTY_NAMES.Length; i++)
                {
                    if (properties[REQUIRED_PROPERTY_NAMES[i]] == null)
                    {
                        throw new ArgumentException("Missing value for " +
                          "command-line parameter " + REQUIRED_PROPERTY_NAMES[i]);
                    }
                }
                return properties;
            }
        }
