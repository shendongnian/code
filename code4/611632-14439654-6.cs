    int startTick=Environment.TickCount;
    while(true){
        int now=Environment.TickCount;
        waitInterval=50-(now-startTick);
        if outputQueue.TryTake(thisSeqName,waitInterval)
        {
            foreach (configurationSequencesSequenceOpcode opcode in sequencesList[thisSeqName])
            {
                outputOpcode(opcode);
                int now=Environment.TickCount;
                waitInterval=50-(now-startTick);
                if (waitInterval<=0)
                {
                    DoPoll();
                    startTick=Environment.TickCount;
                }
            }
        }
        else
        {
            DoPoll();
            startTick=Environment.TickCount;
        }
    }
   
