    public class name // 1
    {
        private string _name1;
        public string get_name1()
        {
             return _name1;
        } 
        public void set_name1(string value)
        {
             this._name1=value;
        } 
        public surname surname = new surname();
    }
    
    public class name // 2
    {        
        private string _name1;
        public string get_name1()
        {
             return _name1;
        } 
        public void set_name1(string value)
        {
             this._name1=value;
        } 
        private surname _surname = new surname();
        public surname get_surname()
        {
             return _surname;
        } 
        public void set_surname(surname value)
        {
             this._surname=value;
        } 
    }
