    var remainingBlockIds = context.ModuleBlocks.Except(toBeDeletedModuleBlocks)
                                                .Select(mb => mb.BID)
                                                .Distinct();
    var toBeDeletedBlocks = context.Blocks.Where(b => remainingBlockIds.Contains(b.BID) == false);
    var toBeDeletedBlockIds = toBeDeletedBlocks.Select(b => b.BID);
    var toBeDeletedBlockLanguages = context.BlockLanguages.Where(bl => toBeDeletedBlockIds.Contains(bl.BID));
    // Then delete toBeDeletedModuleBlocks, toBeDeletedBlocks, and toBeDeletedBlockLanguages 
