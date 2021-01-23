        using System;
    
    namespace Yaser_Jaradeh
    {
        [Serializable]
        public class Sub: ICloneable
        {
            string name;
    
            int studentsNumber;
            int unassaignedStudent;
    
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
    
            public Sub(string name, int number)
            {
                this.name = name;
                this.studentsNumber = number;
                this.unassaignedStudent = number;
            }
    
            public bool Assigne(int count)
            {
                //stuff
                return true;
            }
    
    
            object ICloneable.Clone()
            {
                // normally you would create a new Sub object and copied all informations
                // over a **private** Constructor  like "return new Sub(yourparams ...)"
                // but you could also do this like i showed you befor
                string stCopie = System.Windows.Markup.XamlWriter.Save(this);
    
                var Copie = System.Windows.Markup.XamlReader.Load(System.Xml.XmlReader.Create(new System.IO.StringReader(stCopie))) as Sub;
                return Copie;
            }
        }
    }
