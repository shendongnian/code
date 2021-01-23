    public class DepthRecursionBehavior : ISpecimenBuilderTransformation
    {
        public ISpecimenBuilder Transform(ISpecimenBuilder builder)
        {
            return new DepthRecursionGuard(builder);
        }
    }
