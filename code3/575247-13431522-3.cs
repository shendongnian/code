    List<TriggerDto> triggerDtos = new List<TriggerDto>();
    
    foreach (Trigger trigger in _triggers)
    {
        triggerDtos.Add(new TriggerDto() { Id = trigger.Id, TriggerName = trigger.ToString(cultureInfo) });
    }
    
    this.TriggerDtos = triggerDtos;
