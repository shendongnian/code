    class Program
    {
        static void Main(string[] args)
        {
            List<PropertyBag> bags = new List<PropertyBag>()
                                         {
                                             new PropertyBag() {Property1 = 1, Property2 = 2},
                                             new PropertyBag() {Property1 = 3, Property2 = 4}
                                         };
            Runme(x => x.Property1, bags);
            Runme(x => x.Property2, bags);
            Console.ReadLine();
        }
        public static void Runme(Expression<Func<PropertyBag, int>> expression, List<PropertyBag> bags)
        {
            var memberExpression = expression.Body as MemberExpression;
            var prop = memberExpression.Member as PropertyInfo;
            bags.ForEach( bag => 
                    Console.WriteLine(prop.GetValue(bag, null))
                );
        }
    }
    public class PropertyBag
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
    }
}
