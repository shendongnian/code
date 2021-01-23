    public abstract class Instruction {
       public Instruction() {
           // do common stuff
       }
    }
    
    public abstract class RealInstructionBase : Instruction {
       public RealInstructionBase() : base() {
           GetRealInstruction();
       }
    
       protected abstract object GetRealInstruction();
    }
