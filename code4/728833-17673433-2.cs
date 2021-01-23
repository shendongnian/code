    public class IsNullVisitor : ExpressionVisitor
    {
        public bool IsNull { get; private set; }
        public object CurrentObject { get; set; }
        protected override Expression VisitMember(MemberExpression node)
        {
            base.VisitMember(node);
            if (CheckNull())
            {
                return node;
            }
            var member = (PropertyInfo)node.Member;
            CurrentObject = member.GetValue(CurrentObject,null);
            CheckNull();
            return node;
        }
        private bool CheckNull()
        {
            if (CurrentObject == null)
            {
                IsNull = true;
            }
            return IsNull;
        }
    }
    public static class Helper
    {
        public static bool IsNull<T>(this T root,Expression<Func<T, object>> getter)
        {
            var visitor = new IsNullVisitor();
            visitor.CurrentObject = root;
            visitor.Visit(getter);
            return visitor.IsNull;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person nullPerson = null;
            var isNull_0 = nullPerson.IsNull(p => p.contact.address.city);
            var isNull_1 = new Person().IsNull(p => p.contact.address.city);
            var isNull_2 = new Person { contact = new Contact() }.IsNull(p => p.contact.address.city);
            var isNull_3 =  new Person { contact = new Contact { address = new Address() } }.IsNull(p => p.contact.address.city);
            var notnull = new Person { contact = new Contact { address = new Address { city = "LONDON" } } }.IsNull(p => p.contact.address.city);
        }
    }
