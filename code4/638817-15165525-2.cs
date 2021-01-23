    public class Employee{
        [XmlIgnore]
        public int ID{get;set;}
        [XmlIgnore]
        public int BossID{get;set;}
        [XmlText]
        public string Name{get;set;}
    
        [XmlElement("Employee")
        public Employee[] Minions{get;set;}
        public SetMinions(List<Employee> list){
           Minions = list.Where(e=>e.BossID==ID).ToArray();
        }
    }
