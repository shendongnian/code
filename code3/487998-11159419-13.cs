      public class MapeamentoChild : ClassMap<Child>
        {
            public MapeamentoChild()
            {
                CompositeId()
                    .KeyReference(_ => _.Parent, "PARENT_ID")
                    .KeyProperty(_ => _.ChildId, "CHILD_ID");
                HasMany(_ => _.Items)
                    .AsSet()
                    .Cascade.All()
                    .Not.OptimisticLock()
                    .KeyColumns.Add("PARENT_ID")
                    .KeyColumns.Add("CHILD_ID");
                Version(Reveal.Member<Child>("version"));
            }
        }
