    public class Structure : IDisposable,ICloneable
    {
        struct datenStruct
        {
            internal int days;
            internal int subjectCount;
            internal int periods;
            internal Period[,] schedualArray;
            internal List<Room> rooms;
        }
        private datenStruct USE;
        
        
        /// <summary>
        /// the number of days in the Schedual
        /// </summary>
        public int Days
        {
            get { return USE.days; }
            set { USE.days = value; }
        }
        
        internal List<Room> Rooms
        {
            get { return USE.rooms; }
            set { USE.rooms = value; }
        }
        /// <summary>
        /// Creates an instance of the Structure object
        /// </summary>
        /// <param name="rooms">a list of the rooms in the Schedual</param>
        public Structure(int days, int periods, List<Room> rooms)
        {
            this.USE.days = days;
            this.USE.periods = periods;
            this.USE.rooms = rooms;
            this.USE.schedualArray = new Period[days, periods];
            this.USE.subjectCount = 0;
            for (int i = 0; i < days; i++)
            {
                for (int j = 0; j < periods; j++)
                {
                    USE.schedualArray[i, j] = new Period(CloneList(ref rooms)); //here i cloned the list to be in the safe side and it didn't work also
                }
            }
        }
        private Structure(datenStruct struc) 
        {
            this.USE = struc;
        }
        internal bool AddSubject(Sub subject, int day, int period)
        {
            //add the subject into inner lists (room)
            return true;
        }
        public void PrintStruct()
        {
            for (int i = 0; i < USE.days; i++)
            {
                for (int j = 0; j < USE.periods; j++)
                {
                    foreach (var subject in USE.schedualArray[i, j].Subjects)
                    {
                        Console.Write("\t\t");
                    }
                    Console.Write("\t\t");
                }
                Console.WriteLine();
            }
        }
        public List<Room> CloneList(ref List<Room> rooms)
        {
            var lst = new List<Room>();
            foreach (var room in rooms)
            {
                lst.Add((Room)room.Clone());
            }
            return lst;
        }
        internal void RemoveSubject(Sub subject)
        {
            //..................
        }
        #region IDisposable Members
        public void Dispose()
        {
           // GC.Collect(g, GCCollectionMode.Forced);
        }
        #endregion
        public object Clone()
        {
            var copie =new datenStruct();
            copie.days = USE.days;
            copie.subjectCount = USE.subjectCount;
            copie.periods = USE.periods;
            var RoomListCopie = new List<Room>();
            foreach (Room origSub in USE.rooms)
                RoomListCopie.Add((Room)origSub.Clone());
            copie.rooms = RoomListCopie;
            copie.schedualArray = new Period[copie.days, copie.periods];
            for (int i = 0; i < copie.days; i++)
            {
                for (int j = 0; j < copie.periods; j++)
                {
                    copie.schedualArray[i, j] = new Period(CloneList(ref copie.rooms));
                }
            }
            return new Structure(copie);
        }
    }
