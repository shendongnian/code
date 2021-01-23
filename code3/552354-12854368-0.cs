    private static Type GetProcessorFromEventType(Type eventType)
    {
        // Assuming phrase "Type" only is present at the end of the EventType name
        var processorName = eventType.Name.Replace("Type", "Processor");
        var processorType = Type.GetType(processorName);
        return processorType;
    }
