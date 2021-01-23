    public class YourObject
    {
    	public YourObject(){
    	
    	}
    
    	public YourObject (DataSet dataSet){
    		//Do work here to load your data set into your Users and other necessary objects.
    
    	}
    
    	public UsersObject Users { get; set; }
    
    	public class UsersObject : List<UserObject> {
    		public Users (){
    
    		}
    	}
    	public class UserObject {
    		public User (){
    
    		}
    
    		public int UserId { get; set; }
    		public DatesObject date { get; set; }
    	}
    
    	public class DatesObject : List<DateObject>{
    		public DatesObject (){
    
    		}
    	}
    
    	public class DateObject {
    		public DateObject () {
    
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
