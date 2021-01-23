    public class MergedFieldProcessor
    {
        private FieldProcessor first;
        private FieldProcessor CreateLink(IEnumerator<Type> processors)
        {
            if(processors.MoveNext())
            {
                FieldProcessor link = (FieldProcessor)Activator.CreateInstance(processors.Current);
                link.NextProcessor = CreateLink(processors);
                return link;
            }
            return null;
        }
        public MergedFieldProcessor()
        {
            var processType = typeof(FieldProcessor);
            var allProcess = processType.Assembly.GetTypes()
                .Where(t => t != processType && processType.IsAssignableFrom(t));
            first = CreateLink(allProcess.GetEnumerator());
        }
        public void Handle(MergedFieldProcessorRequest request)
        {
            first.ProcessRequest(request);
        }
    }
