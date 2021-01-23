    // The movie IDs
    IEnumerable<int> movieIds = ...;
    
    // The actions.
    var actions = movieIds.Select(
        i => new { Id = i, Action = new ActionBlock<Frame>(MethodToProcessFrame) });
    
    // The buffer block.
    BufferBlock<Frame> buffer = ...;
    
    // Link everything up.
    foreach (var action in actions) 
    {
        // Not necessary in C# 5.0, but still, good practice.
        // The copy of the action.
        var actionCopy = action;
    
        // Link.
        bufferBlock.LinkTo(actionCopy.Action, f => f.MovieId == actionCopy.Id);
    }
