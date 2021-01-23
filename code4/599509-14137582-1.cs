    public interface IBase { }
    public interface IDerivied : IBase { }
    public interface IDeriviedLeft : IDerivied, IDisposable { }
    public interface IDeriviedRight : IDerivied { }
    
    public class DeriviedLeft : IDeriviedLeft
    {
        public void Dispose() { }
    }
    public class SubDeriviedLeft : DeriviedLeft { }
    public class DeriviedRight : IDeriviedRight { }
    public class Another { }
    public class AnotherDisposable : IDisposable
    {
        public void Dispose() { }
    }
