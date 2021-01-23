    public class YourObject
    {
     public string Pror1 {get;set;}
     public string Pror2 {get;set;}
    }
 
    List<YourObject> result=from row1 in dsResults.Tables[0].AsEnumerable()
        join row2 in dsResults.Tables[1].AsEnumerable()
         on row1.Field<decimal>("RecordId") equals row2.Field<decimal>("RecordId2")
         select new YourObject()
         {
           Pror1=row1.prop1,
           Prop2=row2.prop2,
           ......
         }.ToList(); 
