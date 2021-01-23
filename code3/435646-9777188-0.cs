    this.Container.Devices.Delete(o => o.Id == 1);
    
    this.Container.Devices.Update(
         o => new Device() { 
            LastOrderRequest = DateTime.Now, 
            Description = o.Description + "teste"
         }, 
         o => o.Id == 1);
