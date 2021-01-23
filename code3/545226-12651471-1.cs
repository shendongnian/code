    private static ITargetBlock<int> BuildPipeline(int NumProductionLines)
    {
        var productionQueue = new BufferBlock<int>();
    
        for (int i = 0; i < NumProductionLines; i++)
        {
            int iCopy = i;
            ActionBlock<int> productionLine = new ActionBlock<int>(
                num => Console.WriteLine("Processed by line {0}: {1}", iCopy + 1, num));
    
            productionQueue.LinkTo(
                productionLine, x => x % NumProductionLines == iCopy);
        }
    
        return productionQueue;
    }
