    public class Period: ICloneable
    {
        struct datenStruct
        {
            internal List<Room> rooms;
            internal List<Sub> subjects;
            internal string name;
            internal int conflicts;
        }
        private datenStruct USE;
        
        internal List<Sub> Subjects
        {
            get { return USE.subjects; }
            set { USE.subjects = value; }
        }
        /// <summary>
        /// Create an instance of class Period
        /// </summary>
        /// <param name="rooms">the rooms in this Period</param>
        public Period(List<Room> rooms)
        {
            this.USE.conflicts = 0;
            this.USE.rooms = rooms;
            this.USE.subjects = new List<Sub>();
            fillSubjects(ref USE.rooms, ref USE.subjects);
        }
        private Period(datenStruct struc)
        {
            USE = struc;
        }
        /// <summary>
        /// Fill the subjects in the rooms to the list of subjects
        /// </summary>
        /// <param name="rooms">referance to the list of the rooms</param>
        /// <param name="subjects">referance to the list of the subjects</param>
        private void fillSubjects(ref List<Room> rooms, ref List<Sub> subjects)
        {
            foreach (var room in rooms)
            {
                foreach (var subject in room.Subjects)
                {
                    if (!subjects.Exists(s => s.Name == subject.Name))
                        subjects.Add(subject);
                }
            }
        }
        /// <summary>
        /// Adds the given subject to the period if there is a place in any room
        /// </summary>
        /// <param name="s">the subject to add</param>
        /// <returns>true if there is space for this subject and added, otherwise false</returns>
        public bool AddSubject(Sub s)
        {
            foreach (var room in USE.rooms)
            {
                if (room.addSubject(s))
                {
                    //stuff
                }
                else
                    if (room.addPartialSubject(s))
                    {
                        //stuff
                    }
            }
            return false;
        }
        private int CalculateConflictions(Sub s)
        {
            //also a lot of stuff 
            return 1;
        }
        public object Clone()
        {
            var copie = new datenStruct();
            copie.name = USE.name;
            copie.conflicts = USE.conflicts;
            var RoomListCopie = new List<Room>();
            foreach (Room origSub in USE.rooms)
                RoomListCopie.Add((Room)origSub.Clone());
            copie.rooms = RoomListCopie;
            var SubListCopie = new List<Sub>();
            foreach (Sub origSub in USE.subjects)
                SubListCopie.Add((Sub)origSub.Clone());
            copie.subjects = SubListCopie;
            return new Period(copie);
        }
    }
