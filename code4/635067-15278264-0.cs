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
                NavigationProperty nav = null;
                PropertyInfo property = this.GetType().GetProperty("NavigationProperty");
                if (property != null)
                {
                    nav = (NavigationProperty)property.GetValue(this, new object[] { });
                }
                return nav;
            }
            set
            {
                PropertyInfo property = this.GetType().GetProperty("NavigationProperty");
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
