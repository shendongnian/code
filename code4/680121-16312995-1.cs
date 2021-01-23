    public class Subclass : People
    {
        public Func<DateTime, ushort> BirthDateToAge;
        ushort _mAge;
    
        public override ushort Age
        {
            get { return AgeImpl(_mAge); }
            set { _mAge = value; }
        }
    }
    
    // And then somewhere else where you'd want to create the "subclass"
    var people = new Subclass();
    Func<DateTime, ushort> setter = (Func<DateTime, ushort>)(bday => (ushort)CalcElapsedYears(bday));
    people.AgeImpl = setter;
