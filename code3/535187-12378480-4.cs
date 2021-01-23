    events.Select(e=> new Event() {
             ID = e.ID, 
             Name = e.Name, 
             EventProcesses = e.EventProcesses.Where( 
                 ep => ep.EventProcessForms.Any())
        .Where(e=>EventProcesses.Any())
        ;
