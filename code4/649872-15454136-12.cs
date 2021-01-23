    public class Sub: ICloneable
    {
        struct datenStruct
        {
            internal int studentsNumber;
            internal int unassaignedStudent;
            internal string name;
        }
        private datenStruct USE;
        int studentsNumber;
        public string Name
        {
            get { return USE.name; }
            set { USE.name = value; }
        }
        private Sub(datenStruct struc)
        {
            this.USE = struc;
        }
        public Sub(string name, int number)
        {
            this.USE = new datenStruct();
            this.USE.name = name;
            this.USE.studentsNumber = number;
            this.USE.unassaignedStudent = number;
        }
        public bool Assigne(int count)
        {
            //stuff
            return true;
        }
        public object Clone()
        {
            var copie = new datenStruct();
            copie.name = USE.name;
            copie.unassaignedStudent = USE.unassaignedStudent;
            copie.studentsNumber = USE.studentsNumber;
            return new Sub(copie);
        }
    }
