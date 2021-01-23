    public abstract class BaseClass
    {
        public int Id { get; set; }
        public abstract string Slug { get; }
    }
    public class State:BaseClass
    {
        public string StateName{ get; set; }
        public abstract string Slug 
        {
            get 
            {
                return Regex.Replace(StateName, '[^a-zA-Z0-9]', '-');
            }
        }
    }
 
