    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management;
    
    namespace WmiEventQuery
    {
        class Program
        {
            static void Main(string[] args)
            {
                SelectQuery query = new SelectQuery("select * from Win32_NtLogEvent where LogFile = 'Application' ");
                //execute the query using WMI
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                //loop through each log found
                List<EventDateTime> datetimesEvents = new List<EventDateTime>();
                foreach (ManagementObject mo in searcher.Get())
                {
                    DateTime firstEventTime;
                    DateTime.TryParseExact(mo["TimeGenerated"].ToString().Substring(0, 12), "yyyyMMddHHmm", null, DateTimeStyles.None, out firstEventTime);
                    
                    datetimesEvents.Add(new EventDateTime
                    {
                        RecordNumber = Convert.ToInt32(mo["RecordNumber"]),
                        TimeGenerated = firstEventTime
                    });
                }
    
                int olderRecordNumber = datetimesEvents.OrderBy(p => p.RecordNumber).FirstOrDefault().RecordNumber;
    
                SelectQuery queryUnique = new SelectQuery(
                    System.String.Format("select * from Win32_NtLogEvent where RecordNumber = {0}", olderRecordNumber)
                    );
    
                ManagementObjectSearcher searcherUnique = new ManagementObjectSearcher(queryUnique);
    
                foreach (ManagementObject mo in searcherUnique.Get())
                {
                    //get the older event
                    Console.WriteLine(mo["Message"]);
                    Console.WriteLine(mo["RecordNumber"]);
                }
    
                Console.Read();
    
            }
        }
    
        public class EventDateTime
        {
            public DateTime TimeGenerated { get; set; }
            public int RecordNumber { get; set; }
        }
    
    }
