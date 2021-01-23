    using System;
    using Microsoft.Management.Infrastructure;
    using Microsoft.Management.Infrastructure.Options;
    using System.Linq;
    namespace MachineTimeStamps
    {
        class Program
        {
            /// <summary>
            /// Print the system Uptime and Last Bootup Time (using Win32_OperatingSystem LocalDateTime & LastBootUpTime properties).
            /// </summary>
            public static void Main(string[] args)
            {
                var uptime = GetSystemUptime("COMPUTER_NAME");
                if (!uptime.HasValue)
                {
                    throw new NullReferenceException("GetSystemUptime() response was null.");
                }
                var lastBootUpTime = GetSystemLastBootUpTime("COMPUTER_NAME");
                if (!lastBootUpTime.HasValue)
                {
                    throw new NullReferenceException("GetSystemLastBootUpTime() response was null.");
                }
                Console.WriteLine($"Uptime: {uptime}");
                Console.WriteLine($"BootupTime: {lastBootUpTime}");
                Console.ReadKey();
            }
            /// <summary>
            /// Retrieves the duration (TimeSpan) since the system was last started.
            /// Note: can be used on a local or a remote machine.
            /// </summary>
            /// <param name="computerName">Name of computer on network to retrieve uptime for</param>
            /// <returns>WMI Win32_OperatingSystem LocalDateTime - LastBootUpTime</returns>
            private static TimeSpan? GetSystemUptime(string computerName)
            {
                string namespaceName = @"root\cimv2";
                string queryDialect = "WQL";
                DComSessionOptions SessionOptions = new DComSessionOptions();
                SessionOptions.Impersonation = ImpersonationType.Impersonate;
                CimSession session = CimSession.Create(computerName, SessionOptions);
                string query = "SELECT * FROM Win32_OperatingSystem";
                var cimInstances = session.QueryInstances(namespaceName, queryDialect, query);
                if (cimInstances.Any())
                {
                    var cimInstance = cimInstances.First();
                    var lastBootUpTime = Convert.ToDateTime(cimInstance.CimInstanceProperties["LastBootUpTime"].Value);
                    var localDateTime = Convert.ToDateTime(cimInstance.CimInstanceProperties["LocalDateTime"].Value);
                    var uptime = localDateTime - lastBootUpTime;
                    return uptime;
                }
                return null;
            }
            /// <summary>
            /// Retrieves the last boot up time from a system.
            /// Note: can be used on a local or a remote machine.
            /// </summary>
            /// <param name="computerName">Name of computer on network to retrieve last bootup time from</param>
            /// <returns>WMI Win32_OperatingSystem LastBootUpTime</returns>
            private static DateTime? GetSystemLastBootUpTime(string computerName)
            {
                string namespaceName = @"root\cimv2";
                string queryDialect = "WQL";
                DComSessionOptions SessionOptions = new DComSessionOptions();
                SessionOptions.Impersonation = ImpersonationType.Impersonate;
                CimSession session = CimSession.Create(computerName, SessionOptions);
                string query = "SELECT * FROM Win32_OperatingSystem";
                var cimInstances = session.QueryInstances(namespaceName, queryDialect, query);
                if (cimInstances.Any())
                {
                    var lastBootUpTime = Convert.ToDateTime(cimInstances.First().CimInstanceProperties["LastBootUpTime"].Value);
                    return lastBootUpTime;
                }
                return null;
            }
        }
    }
