	public class User {
	   public int id {get;set;}
	}
	public class Relationship{
	 public User User1{get;set;}
	 public User User2{get;set;}
	 public DateTime StateChangeDate {get;set;}
	
	 //RelationshipState is an Enum with int values
	 public RelationshipState State {get;set;}
	}
    void Main()
    {
	
	var rs=new List<Relationship>() {
	 new Relationship{ User1=new User{id=1},User2=new User{id=2},StateChangeDate=DateTime.Parse("1/1/2013"),State=RelationshipState.state2},
	 new Relationship{ User1=new User{id=1},User2=new User{id=2},StateChangeDate=DateTime.Parse("1/2/2013"),State=RelationshipState.state3},
	 new Relationship{ User1=new User{id=1},User2=new User{id=3},StateChangeDate=DateTime.Parse("1/1/2013"),State=RelationshipState.state2},
	 new Relationship{ User1=new User{id=1},User2=new User{id=3},StateChangeDate=DateTime.Parse("1/2/2013"),State=RelationshipState.state1},
	 new Relationship{ User1=new User{id=2},User2=new User{id=3},StateChangeDate=DateTime.Parse("1/2/3013"),State=RelationshipState.state1}
	};
	
	var result=rs.GroupBy(cm=>new {id1=cm.User1.id,id2=cm.User2.id},(key,group)=>new {Key1=key,Group1=group.OrderByDescending(g=>g.StateChangeDate)})
	.Where(r=>r.Group1.Count()>1) // Remove Entries with only 1 status
	.Where(r=>r.Group1.First().State<r.Group1.Skip(1).First().State) // Only keep relationships where the state has gone done
	;
	
	result.Dump();
    }
