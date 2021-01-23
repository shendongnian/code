    public static T Choose<T>(string name)
            // type constraint to ensure hierarchy.
            where T : BaseClass // BaseClass have common functionality of both class.
        {
            // Unfortunately you can't create instance with generic and pass arguments
            // to ctor. So you have to use Activator here.
            return (T)Activator.CreateInstance(typeof(T), new[] { name });
        }
