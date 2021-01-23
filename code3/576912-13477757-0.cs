    partial class Teacher
    {
        public IEnumerable<Pupil> Boys
        {
            get { return Pupils.Where(x => x.IsMale); }
        }
        public IEnumerable<Pupil> Girls
        {
            get { return Pupils.Where(x => !x.IsMale); }
        }
    }
