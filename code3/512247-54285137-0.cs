    routes.MapHub<SignalRHub>("/rt", options =>
    {
         // when run in debug mode only WebSockets are allowed
         if (Debugger.IsAttached) {
            options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
         }
    });
