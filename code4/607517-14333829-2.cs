    //an interface (optional)
    public interface IAxis {
       void MoveToPos(int pos);
    }
    
    public abstract class AxisBase : IAxis {
       public void MoveToPos(int pos) {
          //implementation
       }
    }
    
    
    //classes inheriting from AxisBase
    public class GateAxis : AxisBase {
       public void CloseGate() {
          MoveToPos(0);
       }
    }
    
    public class XAxis : AxisBase {
       public void MoveToStart() {
         MoveToPos(100);
       }
    }
