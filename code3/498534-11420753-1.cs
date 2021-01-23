    Task.Factory.ContinueWhenAll(tasks, t => {
         // Note that t is an array of Task, so you have to cast to 
         // Task<WebRequest>.
         // Process all of them here.
    });
