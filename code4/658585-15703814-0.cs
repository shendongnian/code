    ViewBag.query = from input in db.field
                                where input.ID_FIELD == 1
                                select new MyType() {
                                    someField = input.FIELD_TYPE 
                                };
    public class MyType
    {
      public int someField {get;set;}//compatible with whatever type FIELD_TYPE is.
    }
