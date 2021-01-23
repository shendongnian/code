    public static class FormsProcessing
    {
        private static ConcurrentDictionary<string, Func<FormProcessor>> _registeredProcessors = new ConcurrentDictionary<string, Func<FormProcessor>>();
        public delegate bool FormProcessor(XmlDocument form);
        public static void RegisterProcessor(string formKey, Func<FormProcessor> formsProcessorFactory)
        {
            _registeredProcessors.AddOrUpdate(formKey, formsProcessorFactory, (k, current) => formsProcessorFactory);
        }
        public static FormProcessor GetProcessorFor(string formKey)
        {
            Func<FormProcessor> processorFactory;
            if (_registeredProcessors.TryGetValue(formKey, out processorFactory);
                return processorFactory();
            return null;
        }
        public static bool Process(string formKey, XmlDocument form)
        {
            var processor = GetProcessorFor(formKey);
            if (null == processor)
                throw new Exception(string.Format("No processor for '{0}' forms available", formKey));
            return processor(form);
        }
    }
