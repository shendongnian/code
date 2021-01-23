    BarServiceClient Create()
    {
        var duplexClient = new BarServiceClient(new InstanceContext(this.barServiceCallback));
        duplexClient.Faulted += this.FaultedHandler;
        duplexClient.Closed += this.ClosedHandler;
        duplexClient.Ping(); // An empty service function to make sure connection is OK
        return duplexClient;
    }
    public class Watcher
    {
    public Watcher()
    {
        this.CommunicationObject = this.Create();
    }
    
    ICommunicationObject CommunicationObject { get; private set; }
    void FaultedHandler(object sender, EventArgs ea)
    {
        this.CommunicationObject.Abort();
    }
    void ClosedHandler(object sender, EventArgs ea)
    {
        this.CommunicationObject.Faulted -= this.FaultedHandler;
        this.CommunicationObject.Closed -= this.ClosedHandler;
        this.CommunicationObject = this.Create();
    }
    }
