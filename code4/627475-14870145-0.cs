public class CustomerDetailsViewModel : INotifyPropertyChanged
{
  public CustomerDetailsViewModel(Customer customer)
  {
    _item = customer;
  }
  private Customer _item;
  
  public string FirstName
  { 
    get { return _item != null ? _item.FirstName : null; }
    set 
    {
      if (_item == null)
        _item = new Customer(); // just an example, probably it's not the desired behavior
      _item.FirstName = value;
      RaisePropertyChanged(...);
    }
  }
  ...
}
