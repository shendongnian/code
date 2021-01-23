    public class Employee{
    public int ID{get;set;}
    public int BossID{get;set;}
    public string Name{get;set;}
    
    public Employee[] Minions{get;set;}
    public SetMinions(List<Employee> list){
       Minions = list.Where(e=>e.BossID==ID).ToArray();
    }
