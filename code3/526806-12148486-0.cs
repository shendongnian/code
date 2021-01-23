    public class ExcelData
    {
       public string PersonName {get;set;}
       public int Age {get;set;}
       public string PhoneNumber {get;set;}
    }
    
    public List<ExcelData> fromExcel = new List<ExcelData>();
    fromExcel.Add(new ExcelData
                      {
                         PersonName = "Joe Smith", 
                         Age = 34, 
                         PhoneNumber = "(123) 456-7890"
                      });
