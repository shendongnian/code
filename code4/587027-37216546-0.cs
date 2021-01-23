    public static T Find<T>(this UITestControl parent) where T : UITestControl, new()
        {
            return new T() { Container = parent };
        }
    public static IEnumerable<T> FindAll<T>(this UITestControl parent) where T : UITestControl, new()
        {
            return parent.Find<T>().FindAllAsType();
        }
    private static IEnumerable<T> FindAllAsType<T>(this T current) where T : UITestControl, new()
        {
            if (typeof(T).IsSubclassOf(typeof(HtmlControl)))
            {
                return current.FindMatchingControls().Select(x => new T().ExtendFrom(x));
            }
            return current.FindMatchingControls().OfType<T>();
        }
    private static IEnumerable<U> FindAllCastTo<T, U>(this T current) where T : UITestControl
        {
            return current.FindMatchingControls().Cast<U>();
        }
