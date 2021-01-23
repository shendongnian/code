    public interface ITransformable { }
    public interface ITransformer<TType>
        where TType: ITransformable
    {
        void Transform(ITransformable source, ITransformable destination);
    }
    public interface ITransformable<TType> : ITransformable
        where TType: ITransformable
    {
        bool Locked { get; set; }
        ITransformer<TType> Transformer { get; set; }
        void TransformFrom(TType source);
    }
    public class MyTransformer : ITransformer<MyTransformable>
    {
        public void Transform(ITransformable source, ITransformable destination)
        {
            // Perform some logic for the transform
        }
    }
    public abstract class Transformable<TType> : ITransformable<TType> where TType: ITransformable
    {
        public bool Locked { get; set; }
        public ITransformer<TType> Transformer { get; set; }
        public void TransformFrom(TType source)
        {
            Transformer.Transform(source, this);
        }
    }
    public class MyTransformable : Transformable<MyTransformable>
    {
    }
