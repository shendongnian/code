    using System;
    using System.Collections.Generic;
    
    namespace Yaser_Jaradeh
    {
        [Serializable]
        public class Room: ICloneable
        {
            string name;
            int studentsNumber;
            int full;
            private int freeSeats;
            List<Sub> subjects;
    
            /// <summary>
            /// the list of subjects
            /// </summary>
            internal List<Sub> Subjects
            {
                get { return subjects; }
                set { subjects = value; }
            }
    
            Dictionary<Sub, int> variations;
    
    
            public Room(string name, int number)
            {
                this.name = name;
                this.studentsNumber = number;
                this.full = 0;
                this.subjects = new List<Sub>();
                this.variations = new Dictionary<Sub, int>();
                this.freeSeats = number;
            }
    
            public Room(int number)
            {
                this.studentsNumber = number;
                this.full = 0;
                this.subjects = new List<Sub>();
                this.variations = new Dictionary<Sub, int>();
                this.freeSeats = number;
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
                string stCopie = System.Windows.Markup.XamlWriter.Save(this);
    
                var Copie = System.Windows.Markup.XamlReader.Load(System.Xml.XmlReader.Create(new System.IO.StringReader(stCopie))) as Room;
                return Copie;
            }
        }
    }
