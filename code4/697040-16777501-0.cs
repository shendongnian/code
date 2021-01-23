    public class Property<TObj, TProp>
    {
        private readonly TObj _instance;
        private readonly PropertyInfo _propInf;
        public Property(TObj o, Expression<Func<TObj, TProp>> expression)
        {
            _propInf = ((PropertyInfo)((MemberExpression)expression.Body).Member);
            _instance = o;
        }
        public TProp Value
        {
            get
            {
                return (TProp)_propInf.GetValue(_instance);
            }
            set
            {
                _propInf.SetValue(_instance, value);
            }
        }
    }
    public class User
    {
        public string Name { get; set; }
    }
    var user = new User();
    var name = new Property<User, string>(user, u => u.Name);
    name.Value = "Mehmet";
    Console.WriteLine(name.Value == user.Name); // Prints True
