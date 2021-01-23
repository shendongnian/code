    List<ReplicateBlock> blocks = new List<ReplicateBlock>();    
    foreach (var item in selectedDates.Where(x => x.Checked))
    {
         var t = lf.ReplicateBlocks.Where(o=> 
                     o.minimumCompletionDate >= item.minDate  &&
                     o.minimumCompletionDate <= item.minDate.AddMinutes(30));
    
         blocks.AddRange(t);
    }
