abstract class paymentBase
{
    public paymentBase(string postUrl) { this.postUrl = postUrl; }
    public int transactionId { get; set; }
    public string item { get; set; }
    protected string postUrl { get; private set; }
    public void payme();
}
class paymentGateWayNamePayment : paymentBase
{
    public paymentGateWayNamePayment() : base("http://myurl.com/payme") {  }
}
