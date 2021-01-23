    public interface IAxis {
    	void MoveToPos(int pos);
    }
    
    public interface IGateAxis {
        void CloseGate();
    }
    
    public interface IXAxis {
        void MoveToStart();
    }
    
    public class TheAxis : IAxis, IGateAxis, IXAxis {
         public TheAxis(){ }
         void IAxis.MoveToPos(int pos) {} 
    	 void IGateAxis.CloseGate() { ((IAxis)this).MoveToPos(0); }
    	 void IXAxis.MoveToStart() { ((IAxis)this).MoveToPos(100); }
    }
    
    IGateAxis gateAxis = new ThisAxis();
    gateAxis.CloseGate();
    
    IXAxis xAxis = new ThisAxis();
    xAxis.MoveToStart();
