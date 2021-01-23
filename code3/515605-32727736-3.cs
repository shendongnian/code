    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
            
        public List<Something> Somethings { get; set; }
        public bool ShouldSerializeSomethings() {
			 var resultOfSomeLogic = false;
             return resultOfSomeLogic; 
		}
    }
