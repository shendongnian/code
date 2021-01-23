    public abstract class Transformable<TType> : ITransformable<TType>
    {
        public bool Locked { get; set; }
        public ITransformer<TType> Transformer { get; set; }
    
        protected abstract TType Value { get; }
    
        public void TransformFrom(TType source)
        {
            Transformer.Transform(source, Value); 
        }
    }
    
    public class MyOtherTransformable : Transformable<MyTransformable>
    {
        protected override MyTransformable Value
        {
            get { return this; }
        }
    }
