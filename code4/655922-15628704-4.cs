        public class YourObject
    {
    	public YourObject(){
    	
    	}
    
    	public YourObject (DataTable dataTable){
    		//Do work here to load your data set into your Users and other necessary objects.
    		Users = new Users(dataTable);
    		
    
    	}
    
    	public UsersObject Users { get; set; }
    
    	public class UsersObject : List<UserObject> {
    		public UsersObject (DataTable dataTable){
    			dataTable.AsEnumerable().Select(row => row.Field<String>("UserId")).Distinct().ToList<String>().ForEach(x => this.Add(new UserObject(){UserId = x}));
    			foreach(UserObject user in this){
    				user.LoadDates(dataTable.Select("UserId = '" + user.UserId + "'"));
    			}
    		}
    	}
    	public class UserObject {
    		public UserObject (){
    			date = new DatesObject();
    		}
    		
    		public void LoadDates(DataRow[] rows){
    			rows.AsEnumerable().Select(row => row.Field<DateTime>("TimeStamp").Date).Distinct().ToList<DateTime>().ForEach(x => this.Add(new DateObject(){TimeStamp = x}));
    			foreach(DateObject date in this){
    				date.LoadParams(rows.Select("TimeStamp = '" + date.TimeStamp.ToString("MM/dd/yyyy") + "'"));
    			}
    		}
    
    		public string UserId { get; set; }
    		public DatesObject date { get; set; }
    	}
    
    	public class DatesObject : List<DateObject>{
    		public DatesObject (){
    
    		}
    	}
    
    	public class DateObject {
    		public DateObject () {
    
    		}
    
    		public void LoadValues(DataRow[] rows){
    			//Load your value/params like in the previous methods
    		}
    
    		public DateTime TimeStamp { get; set; }
    		public ValuesObject Values { get; set; }
    	}
    
    	public class ValuesOject : List<ValueObject> {
    		public ValuesOject () {
    
    		}
    	}
    
    	public class ValueObject {
    		public ValueObject () {
    
    		}
    		public string Parameter { get; set; }
    		public string Value { get; set; }
    	}
    }	
