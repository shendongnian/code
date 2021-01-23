    private static ITargetBlock<int> BuildPipeline(int NumProductionLines)
    {
        var productionQueue = new BufferBlock<int>();
    
        for (int i = 0; i < NumProductionLines; i++)
        {
            ActionBlock<int> productionLine = new ActionBlock<int>(
                num => Console.WriteLine("Processed by line {0}: {1}", i + 1, num));
    
            int iCopy = i;
    
            productionQueue.LinkTo(
                productionLine, x => x % NumProductionLines == iCopy);
        }
    
        return productionQueue;
    }
