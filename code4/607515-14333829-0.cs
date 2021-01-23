    //an interface (optional)
    public interface IAxis {
       void IMoveToPos(int pos);
    }
    
    public abstract class AxisBase : IAxis {
       protected void IMoveToPos(int pos) {
          //implementation
       }
    }
    
    
    //classes inheriting from AxisBase
    public class GateAxis : AxisBase {
       public void CloseGate() {
          IMoveToPost(0);
       }
    }
    
    public class XAxis : AxisBase {
       public void MoveToStart() {
         IMoveToPost(100);
       }
    }
