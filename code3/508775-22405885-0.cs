    void Main()
    {
    	var db = new DataBase();
    	var sql= (from u in db.USER
              join c in db.CONSULT on u.IdUser equals c.IdUser 
    		  group c by new { c.IdUser, c.DateCreate, c.IdTypeConsult, u.Sex } into gc
              select new UsuersViewModel 
                     {  
                        IdUser = gc.Key.IdUser, 
                        DateCreate=gc.Key.DateCreate, 
                        IdTypeConsult = gc.Key.IdTypeConsult, 
                        Sex=gc.Key.Sex 
                     })
                     .Distinct();
    	sql.Dump("SQL Distinct Demo");
    }
    public class Consultation {
    	public int	IdUser {get;set;}
    	public DateTime DateCreate {get;set;}
    	public int IdTypeConsult {get;set;}
    }
    public class UsuersViewModel : Consultation {
    	public string Sex {get;set;}
    }
    public class DataBase {
    	public IEnumerable<Consultation> CONSULT {
    		get { 
    			return new List<Consultation>{
    				new Consultation { IdUser = 1, DateCreate=DateTime.Today, IdTypeConsult = 2},
    				new Consultation { IdUser = 2, DateCreate=DateTime.Today.AddDays(1), IdTypeConsult = 4}
    			};
    		}}
    	public IEnumerable<UsuersViewModel> USER {
    		get {
    			return new List<UsuersViewModel>{
    				new UsuersViewModel { IdUser = 1, Sex="M"},
    				new UsuersViewModel { IdUser = 1, Sex="M"},
    				new UsuersViewModel { IdUser = 2, Sex="F"},
    				new UsuersViewModel { IdUser = 2, Sex="F"}
    			};
    		}}
    }
    
