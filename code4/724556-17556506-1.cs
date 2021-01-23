    public abstract class BaseType
    {
        public abstract void DoWork();
    }
    public class TypeA : BaseType
    {
        public override void DoWork() {
            // do work on Type A
        }
    }
    public class TypeB : BaseType
    {
        public override void DoWork() {
            // do work on Type B
        }
    }
