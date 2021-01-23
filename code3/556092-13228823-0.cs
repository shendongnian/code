    internal sealed class SampleRule : BaseIntrospectionRule
    {
        
        public override ProblemCollection Check(Member member)
        {
            const string typeName = "System.DateTime";
            var field = member as Field;
            if (field == null || field.Type.FullName != typeName)
                return null;
            return new ProblemCollection 
            { 
                new Problem(new Resolution(field.Name.Name, "Type {0} is obsolete", typeName)) 
            };
        }
    }
