    public class LogFileItem
    {
       public string IpAddress {get; set;}
       public string Sysname {get; set;}
       public string Username {get; set;}
       public string Text {get; set;}
       public DateTime DateTime {get; set;}
       public static List<LogFileItem> ParseLogFile(string path)
       {
         List<LogFileItem> result = new List<LogFileItem>();
         string line;
         StreamReader strRead = new StreamReader(path);
         {
           int row = 0;
       
           while ((line = strRead.ReadLine()) != null)
           {
             string[] columns = line.Split('|');
             LogFileItem item = new LogFileItem();
             item.IpAddress = columns[0];
             item.Sysname = columns[1];
             item.Username = columns[2];
             item.Text = columns[3];
             //this assumes that the dateTime column is parsable by .net
             item.DateTime = DateTime.Parse(columns[4]);
             }
             row++;
           }
         }
       }
    }
