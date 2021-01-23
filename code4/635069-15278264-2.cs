    public class NavigationProperty
    {
        public NavigationProperty(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
    public abstract class Base
    {
        public NavigationProperty NavigationProperty
        {
            get
            {
                string propertyName = MethodBase.GetCurrentMethod().Name.Replace("get_", string.Empty);
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    nav = (NavigationProperty)property.GetValue(this, new object[] { });
                }
                return nav;
            }
            set
            {
                string propertyName = MethodBase.GetCurrentMethod().Name.Replace("set_", string.Empty);
                PropertyInfo property = this.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    property.SetValue(this, value, new object[] { });
                }
            }
        }
    }
    public class Child1 : Base {
        public NavigationProperty NavigationProperty { get; set; }
        public int NavigationPropertyId { get; set; }
    }
    public class Child2 : Base{
        public NavigationProperty NavigationProperty { get; set; }
    }
