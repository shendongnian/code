    private enum ProcessorType
    {
        Undefined,
        Word,
        Pdf
    }
    public void Main(string[] args)
    {
        ValidateArgs(args); // implementation omitted
        ProcessorType requestedProcessor = GetRequestedProcessorFromArgs(args); // implementation omitted
        IFileProcessor processor = GetProcessor(requestedProcessor);
        processor.CompileThis();
    }
    private IFileProcessor GetProcessor(ProcessorType requestedProcessorType)
    {
        switch (requestedProcessorType)
        {
            case ProcessorType.Pdf:
                return new PdfProcessor();
            case ProcessorType.Word:
                return new WordProcessor();
            default:
                throw new ArgumentException("requestedProcessorType");
        }
    }
  
