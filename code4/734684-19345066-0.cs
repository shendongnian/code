    ctx.AddToDevices(new Device{...});
    ctx.BeginSaveChanges(new AsynCallback(r=>{
         DataServiceResponse dsr = ctx.EndSaveChanges(r);
         if (dsr.Any(op => op.Error != null))
         {
           //Show error message
         }
         else
         {
           //Succeeded
         }
    },null);
