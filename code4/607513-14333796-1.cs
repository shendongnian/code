        // super class
        abstract class TheAxis : IAxis {
            public TheAxis() { }
            public void IMoveToPos(int pos) { } //This is forced by the Interface
        }
        abstract class GateAxis : TheAxis {
            public virtual void CloseGate() { IMoveToPos(0); }
        }
        abstract class XAxis : TheAxis {
            public virtual void MoveToStart() { IMoveToPos(100); }
        }
