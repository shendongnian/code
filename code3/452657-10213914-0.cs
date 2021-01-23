    class UserAndValues
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [FieldConverter(typeof(MyListConverter))] 
        public ICollection<UserFavourites> Favourites {get;set;}
    }
    public class MyListConverter: ConverterBase 
    { 
    
        public override object StringToField(string from) 
        { 
          throw new NotImplemented("bad luck");
        } 
        	 
        public override string FieldToString(object fieldValue) 
        { 
           var list = fieldValue as ICollection<UserFavourites>;
            return string.Join(",", 
                list.Select(f => f.ToString()));   // customize
        }
    
    }
