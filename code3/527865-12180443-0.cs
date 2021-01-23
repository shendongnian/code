    public struct myStruct
    { 
        public MyOwnType value1; 
        public int value2; 
        public int value3; 
        public myStruct(MyOwnType val1, int val2, int val3){ 
            value1 = val1; 
            value2 = val2; 
            value3 = val3; 
        } 
    }
    public class MyOwnType
    {
        public int Id { get; set; }
        public MyOwnType(int id)
        {
            this.Id = id;
        }
    }
