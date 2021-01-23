    class PC
    {
        public IEnumerable<Processor> Processors {get; private set;}
    
        // Constructor
        public PC()
        {
            Processors = new List<Processor>();
            for (var i = 0; i < GetProcessorCount(); i++)
                Processors.Add(new Processor(i));
        }
    }
    
    class Processor
    {
        public int ProcessorIndex { get; private set; }
    
        private String _architecture;
        public string Architecture { 
            get { 
                // Return architecture if it's already been retrieved, 
                // otherwise retrieve it, store it, and return it.
                return _architecture ?? (_architecture == getArchitecture(ProcessorIndex));
            }
        }
        public Processor(int processorIndex) {
            ProcessorIndex = processorIndex;
        }
    }
