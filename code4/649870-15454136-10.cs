    using System;
    using System.Collections.Generic;
    
    namespace Yaser_Jaradeh
    {
        [Serializable]
        class Structure : IDisposable,ICloneable
        {
            int days;
            int subjectCount;
            /// <summary>
            /// the number of days in the Schedual
            /// </summary>
            public int Days
            {
                get { return days; }
                set { days = value; }
            }
    
            int periods;
    
    
            Period[,] schedualArray;
    
            List<Room> rooms;
    
            internal List<Room> Rooms
            {
                get { return rooms; }
                set { rooms = value; }
            }
    
            /// <summary>
            /// Creates an instance of the Structure object
            /// </summary>
            /// <param name="rooms">a list of the rooms in the Schedual</param>
            public Structure(int days, int periods, List<Room> rooms)
            {
                this.days = days;
                this.periods = periods;
                this.rooms = rooms;
                this.schedualArray = new Period[days, periods];
                this.subjectCount = 0;
                for (int i = 0; i < days; i++)
                {
                    for (int j = 0; j < periods; j++)
                    {
                        schedualArray[i, j] = new Period(CloneList(ref rooms)); //here i cloned the list to be in the safe side and it didn't work also
                    }
                }
            }
    
            internal bool AddSubject(Sub subject, int day, int period)
            {
                //add the subject into inner lists (room)
                return true;
            }
    
            public void PrintStruct()
            {
                for (int i = 0; i < days; i++)
                {
                    for (int j = 0; j < periods; j++)
                    {
                        foreach (var subject in schedualArray[i, j].Subjects)
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
    
            object ICloneable.Clone()
            {
                string stCopie = System.Windows.Markup.XamlWriter.Save(this);
    
                var Copie = System.Windows.Markup.XamlReader.Load(System.Xml.XmlReader.Create(new System.IO.StringReader(stCopie))) as Structure;
                return Copie;
            }
        }
    }
