    public class Room: ICloneable
    {
        struct datenStruct
        {
            internal int studentsNumber;
            internal int full;
            internal string name;
            internal int freeSeats;
            internal List<Sub> subjects;
            internal Dictionary<Sub, int> variations;
        }
        private datenStruct USE;
        /// <summary>
        /// the list of subjects
        /// </summary>
        internal List<Sub> Subjects
        {
            get { return USE.subjects; }
            set { USE.subjects = value; }
        }
        public Room(string name, int number)
        {
            this.USE = new datenStruct();
            this.USE.name = name;
            this.USE.studentsNumber = number;
            this.USE.full = 0;
            this.USE.subjects = new List<Sub>();
            this.USE.variations = new Dictionary<Sub, int>();
            this.USE.freeSeats = number;
        }
        public Room(int number)
        {
            this.USE = new datenStruct();
            this.USE.studentsNumber = number;
            this.USE.full = 0;
            this.USE.subjects = new List<Sub>();
            this.USE.variations = new Dictionary<Sub, int>();
            this.USE.freeSeats = number;
        }
        private Room(datenStruct struc)
        {
            USE = struc;
        }
        public bool addSubject(Sub sbj)
        {
            //also stuff
            return false;
        }
        public bool addPartialSubject(Sub sbj)
        {
            //stuff
            return false;
        }
        public object Clone()
        {
            var copie = new datenStruct();
            copie.studentsNumber = USE.studentsNumber;
            copie.full = USE.full;
            copie.freeSeats = USE.freeSeats;
            var SubListCopie = new List<Sub>();
            foreach (Sub origSub in USE.subjects)
                SubListCopie.Add((Sub)origSub.Clone());
            copie.subjects = SubListCopie;
            var SubDictCopie = new Dictionary<Sub, int>();
            foreach (KeyValuePair<Sub, int> KvP in USE.variations)
                SubDictCopie.Add((Sub)KvP.Key.Clone(),KvP.Value);
            copie.variations = SubDictCopie;
            return new Room(copie);
        }
    }
