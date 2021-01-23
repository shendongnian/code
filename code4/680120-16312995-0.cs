    public class Subclass : People
    {
        public Func<ushort, ushort> AgeImpl;
        ushort _mAge;
    
        public override ushort Age
        {
            get { return AgeImpl(_mAge); }
            set { _mAge = value; }
        }
    }
    
    // And then somewhere else where you'd want to create the "subclass"
    var people = new Subclass();
    Func<ushort, ushort> setter = (Func<ushort, ushort>)System.Linq.Expressions.Expression.Lambda(/* FILL ME IN */).Compile();
    people.AgeImpl = setter;
