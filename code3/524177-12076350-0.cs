    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace QuestHint
    {
        class QHint
        {
            public QHint() { }
            public QHint(int ID, string Q, string Hint)
            {
                this.ID = ID;
                this.Q = Q;
                this.Hint = Hint;
            }
    
            public int ID { get; set; }
            public string Q { get; set; }
            public string Hint { get; set; }
            public List<QHint> QHintList = new List<QHint>();
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                QHint q = new QHint();
    
                q.QHintList.Add(new QHint(1, "quesiton1 blah blah?", "hint1 blah blah"));
                q.QHintList.Add(new QHint(42, "quesiton2 blah blah?", "hint2 blah blah"));
    
    
                int magicNumber = 42;
    
                Debug.WriteLine(q.QHintList[0].Q); // output quesiton1 blah blah?
                Debug.WriteLine(q.QHintList.Find(obj => obj.ID == magicNumber).Hint); //hint2 blah blah
    // you are saying like: find me the obj, where the ID of that obj is equals my magicNumber. And from that found object, give me the field Hint.
            }
        }
    }
    
