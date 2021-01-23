    public class Test
    {
        public static readonly PropertyInfo TitleProperty = ReflectionHelper.GetPropertyInfo<Test>(x => x.Title);
    
        public string Title { get; set; }
    }
