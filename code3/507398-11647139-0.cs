    static void Main(string[] args)
    {
    	Database.SetInitializer<NerdDinners>(new MyInitializer());
    
    	string connectionstring = "Data Source=.;Initial Catalog=NerdDinners;Integrated Security=True;Connect Timeout=30";
    	using (var db = new NerdDinners(connectionstring))
    	{
    		CreateClubs(db);
    		InsertPersons(db);
    	}
    
    }
    
    public static void CreateClubs(NerdDinners db)
    {
    	Club club1 = new Club();
    	club1.ClubName = "club1";
    
    	Club club2 = new Club();
    	club2.ClubName = "club2";
    
    	Club club3 = new Club();
    	club3.ClubName = "club3";
    
    	db.Clubs.Add(club1);
    	db.Clubs.Add(club2);
    	db.Clubs.Add(club3);
    
    	int recordsAffected = db.SaveChanges();
    }
    
    public static Club GetClubs(string clubName, NerdDinners db)
    {
    	//var query = db.Clubs.Where(p => p.ClubName == clubName);
    	var query = db.Clubs.SingleOrDefault(p => p.ClubName == clubName);
    	return query;
    }
    
    public static void InsertPersons(NerdDinners db)
    {
    	Club club1 = GetClubs("club1", db);
    	Club club2 = GetClubs("club2", db);
    	Club club3 = GetClubs("club3", db);
    
    	Person p1 = new Person();
    	p1.PersonName = "Person1";
    
    	Person p2 = new Person();
    	p2.PersonName = "Person2";
    
    	List<Club> clubsForPerson1 = new List<Club>();
    	clubsForPerson1.Add(club1);
    	clubsForPerson1.Add(club3);
    
    	List<Club> clubsForPerson2 = new List<Club>();
    	clubsForPerson2.Add(club2);
    	clubsForPerson2.Add(club3);
    
    	p1.Clubs = clubsForPerson1;
    	p2.Clubs = clubsForPerson2;
    
    	db.Persons.Add(p1);
    	db.Persons.Add(p2);
    
    	int recordsAffected = db.SaveChanges();
    }
