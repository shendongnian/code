    public class RecordParser
    {
       private List<Record> records;
       private Record currentRecord;
       private string allContent;
       private string currentSection;
    
       public RecordParser(string content)
       {
          this.allContent = content;
       }
    
       public IEnumerable<Record> Split()
       {
          records = new List<Record>();
    
          foreach(string section in GetSections())
          {
              this.currentSection = section;
              this.currentRecord = new Record();
    
              ParseSection();
    
              records.Add(currentRecord);
          }
    
          return records;
       }
    
       private IEnumerable<string> GetSections()
       {
          // Split allContent as needed and return the string sections
       }
    
       private void ParseSection()
       {
          ParseId();
          ParseProcessName();
       }
    
       private void ParseId()
       {
          int id = // Get ID from 'currentRecord'
          currentRecord.ID = id;
       }
    
       private void ParseProcessName()
       {
          string processName = // Get ProcessNamefrom 'currentRecord'
          currentRecord.ProcessName = processName;
       }
    
       /** Add methods with no parameters and use local variables
    }
