c#
app.UseSignalR(routes =>
{
    routes.MapHub<YourHub>(NotificationsRoute); // defined as string
});
c#
services.AddSignalR(hubOptions =>
{
    // your options
})
Then you implement a interface like:
c#
public interface IYourHub
{
    // Your interface implementation
}
And your hub:
c#
public class YourHub : Hub<IYourHub>
{
	// your hub implementation
}
Finally you inject the hub like:
c#
private IHubContext<YourHub, IYourHub> YourHub
{
    get
    {
        return this.serviceProvider.GetRequiredService<IHubContext<YourHub, IYourHub>>();
    }
}
Also you can define a service for your hub (middleware) and don't inject the context directly to your class.
Imagine you defined in the interface the method ```Message``` so in your class you can send the message like this:
c#
await this.YourHub.Clients.Group("someGroup").Message("Some Message").ConfigureAwait(false);
If not implemented in a interface you just use:
c#
await this.YourHub.Clients.Group("someGroup").SendAsync("Method Name", "Some Message").ConfigureAwait(false);
