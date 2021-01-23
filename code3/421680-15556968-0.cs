    abstract internal class Base {
        internal protected abstract void DoProcess();
        public void Process() {
            DoProcess();
        }
    }
    public sealed class Derived : Base {
        internal protected override void DoProcess() {
            throw new NotImplementedException();
        }
    }
