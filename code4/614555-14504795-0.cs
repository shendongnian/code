    public class EmployeeViewModel : ReactiveObject
    {
    private AddressViewModel address;
    private IDisposable addressSubscription;
    public AddressViewModel Address
    {
        get { return this.address; }
        set 
        { 
            if (addressSubscription != null)
            {
                addressSubscription.Dispose();
                addressSubscription =null;
            }
            if (value != null)
            {
                addressSubscription = value.Subscribe(...);
            }
            this.RaiseAndSetIfChanged(x => x.Address, ref this.address, value); 
         }
    }
}
