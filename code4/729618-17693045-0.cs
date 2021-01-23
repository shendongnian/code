    static void Main(string[] args)
            {
                Table table = new Table();
                int count1 = table.records.Where(r => r.Play == false && r.Outlook.ToLower() == "sunny").Count();
            }
    
            public class Record
            {
                public bool Play;
                public string Outlook;
            }
            
    
            public class Table
            {
                //This should be private and Table should be IEnumarable
                public List<Record> records = new List<Record>(); 
    
            }
