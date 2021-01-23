    //an interface (optional)
    public interface IAxis {
       void MoveToPos(int pos);
    }
    
    public abstract class AxisBase : IAxis {
       public void MoveToPos(int pos) {
          //implementation
       }
    }
    //optionally you can do an IGateAxis interface, inheriting (or not) from IAxis
    public interface IGateAxis : IAxis {
       void CloseGate();
    }
    
    //classes inheriting from AxisBase, implementing IGateAxis
    public class GateAxis : AxisBase, IGateAxis {
       public void CloseGate() {
          MoveToPos(0);
       }
    }
    //another class inheriting from AxisBase, without specific interface
    public class XAxis : AxisBase {
       public void MoveToStart() {
         MoveToPos(100);
       }
    }
