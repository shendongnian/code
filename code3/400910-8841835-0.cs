    class Person : IStoreable { 
        public virtual void Read() { Console.WriteLine("Person.Read()"); } 
        public virtual void Write() { Console.WriteLine("Person.Write()"); } 
    } 
    class Student : Person { 
        public override void Read() { Console.WriteLine("Student.Read()"); } 
        public override void Write() { Console.WriteLine("Student.Write()"); } 
