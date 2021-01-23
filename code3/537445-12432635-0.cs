    public abstract class AbstractFactory<K,V>{}
    public sealed class CornerProcessorFactory<K,V> : 
        AbstractFactory<K, V> 
        where K : IFoo 
        where V : struct{ }
