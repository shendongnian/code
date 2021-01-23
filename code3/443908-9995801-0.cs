        [Serializable]
        public class CollectionFilterAspect : OnMethodBoundaryAspect
        {
            public override void OnExit(MethodExecutionArgs args)
            {
                base.OnExit(args);
                IQueryable<Contact> retVal = (IQueryable<Contact>)args.ReturnValue;
                args.ReturnValue = from r in retVal where r.LastName.Contains("S") select r;
            }
        }  
