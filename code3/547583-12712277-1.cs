    var outputs = new BlockingCollection<string>();
    
    // aka Producer
    Action fill = () => {
        Parallel.ForEach(extractor.Results, x => outputs.Add(transformer.Transform(x)));        
        outputs.CompleteAdding();
    };
    
    // aka Consumer
    Action load = () => {
       foreach(var o in outputs.GetConsumingEnumerable()) 
           loader.Load(o);
    }
    
    Parallel.Invoke(fill, load);
