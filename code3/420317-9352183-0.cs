    [Table(name="MyTable")]    
    public class B : A
        {
            
    [Key(column_name="id")]    
    public Int32 B_ID;
            public String B_Value;
        
            public Int32 getID()
            {
                return B_ID;
            }
        
            public void setID(Int32 value)
            {
                B_ID = value;
            }
        }
