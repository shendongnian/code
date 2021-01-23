    public interface IMyType {}
    public class A : IMyType {}
    public class B : IMyType {}
    public class C : IMyType {}
    
    public interface IGeneralPropertyMap<out T> where T : IMyType {} 
