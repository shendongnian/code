    interface IDifferentTypeVisitor
    {
        void Visit(DateTimeType dt);
        void Visit(StringType st);
    }
    
    class DifferentType
    {
        public abstract void Accept(IDifferentTypeVisitor visitor);
    }
    
    class DateTimeType : DifferentType
    {
        public void Accept(IDifferentTypeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    
    class StringType : DifferentType
    {
        public void Accept(IDifferentTypeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    
    class SomeVisitor : IDifferentTypeVisitor
    {
        public void Visit(DateTimeType dt)
        {
            //DateTime resDateTime = dt.Value; Or similar
        }
    
        public void Visit(StringType st)
        {
            //string resString = st.Value; Or similar
        }
    }
    
    public class testTypes2
    {
        public testTypes2()
        {
            var values = new List<DifferentType> { /* Content */ };
            var visitor = new SomeVisitor();
    
            foreach (var i in values)
            {
                i.Accept(visitor);
            }
        }
    }
