    public ClassA
    {
        public ClassA(){
            MyProperty1 = new SomeModelType1();
            MyProperty2 = new List<SomeModelType2>();
        }
    
        public SomeModelType1 MyProperty1 { get; set; }
        public List<SomeModelType2> MyProperty2 { get; set; }
    }
    
    public class SomeModelType1 
    {
        public SomeModelType1(){
            MyProperty13 = new SomeModelType3();
        } 
        public string Name { get; set; }
        public SomeModelType3 MyProperty13 { get; set; }
    }
    public class SomeModelType3
    {
        public int Id { get; set; }
    }
