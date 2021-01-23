    void Main()
    {
    var student1=new Student{Name="Bob"};
    var student2=new Student{Name="Jim"};
    	
    var lstStudent=new List<Student>();
    lstStudent.Add(student1);
    lstStudent.Add(student2);
    
    var lstCopy=new List<Student>(lstStudent);
    var clone=Clone(lstStudent);
    
    student1.Name="JOE";
    
    lstCopy.Dump();
    lstStudent.Dump();
    clone.Dump();
    }
    
    public List<Student> Clone(List<Student> source){
    
    BinaryFormatter bf=new BinaryFormatter();
       using(var ms=new MemoryStream())
       {
         bf.Serialize(ms,source);
         ms.Seek(0,0);
         return (List<Student>)bf.Deserialize(ms);
       }
    }
    
    [Serializable]
    public class Student
    {
      public string Name { get; set; }
    }
