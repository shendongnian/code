    List<object> list = ((IList<object>)service.EventosDoDia()).ToList();
    
    var event = new List<Evento>();
    list.ForEech(c => 
                   {
                     event.Add(new Evento()
                               {
                                 id = c.SomeIdFromService,
                                 logo = c.SomeForLogoService
                                 //TOPO: Some Properties
                               };
                   });
