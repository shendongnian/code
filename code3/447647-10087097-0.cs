    foreach (var blockItems in blockEntities){
         foreach (ADMDatabase.Block b in blockItems)
                {
                    BlockContract blockContract = new BlockContract
                    {
                        blockId = b.blockId,
                        name = b.name,
                        orderInForm = b.orderInForm
                    };
                    blocksList.Add(blockContract);
                }
    }
