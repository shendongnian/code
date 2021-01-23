    using System;
    using System.Collections.Generic;
    
    namespace Yaser_Jaradeh
    {
        [Serializable]
        public class Period: ICloneable
        {
            List<Room> rooms;
    
    
            int conflicts;
    
    
            List<Sub> subjects;
            internal List<Sub> Subjects
            {
                get { return subjects; }
                set { subjects = value; }
            }
    
    
            /// <summary>
            /// Create an instance of class Period
            /// </summary>
            /// <param name="rooms">the rooms in this Period</param>
            public Period(List<Room> rooms)
            {
                this.conflicts = 0;
                this.rooms = rooms;
                subjects = new List<Sub>();
                fillSubjects(ref rooms, ref subjects);
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
                foreach (var room in rooms)
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
                string stCopie = System.Windows.Markup.XamlWriter.Save(this);
    
                var Copie = System.Windows.Markup.XamlReader.Load(System.Xml.XmlReader.Create(new System.IO.StringReader(stCopie))) as Period;
                return Copie;
            }
        }
    }
