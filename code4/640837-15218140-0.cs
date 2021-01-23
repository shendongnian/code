    public partial class Participant
    {
        public static readonly Expression<Func<Participant, string>>
            NameExpression = p => p.Person.Name;
        
        public static readonly Expression<Func<Participant, string>>
            FirstNameExpression = p => p.Person.FirstName;
