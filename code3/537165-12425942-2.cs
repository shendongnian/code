    public class GreedyEngineParts : DefaultEngineParts
    {
        public override IEnumerator<ISpecimenBuilder> GetEnumerator()
        {
            var iter = base.GetEnumerator();
            while (iter.MoveNext())
            {
                if (iter.Current is MethodInvoker)
                    yield return new MethodInvoker(
                        new CompositeMethodQuery(
                            new GreedyConstructorQuery(),
                            new FactoryMethodQuery()));
                else
                    yield return iter.Current;
            }
        }
    }
