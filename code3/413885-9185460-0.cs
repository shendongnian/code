       public class OrderScreenViewModel : INotifyPropertyChanged
       {
          private readonly IProductRepository _productRepository;
          private readonly ICustomerRepository _customerRepository;
    
          public OrderScreenViewModel(IProductRepository productRepository,
             ICustomerRepository customerRepository)
          {
             _productRepository = productRepository;
             _customerRepository = customerRepository;
    
             BuildCustomersCollection();
          }
    
          private void BuildCustomersCollection()
          {
             var customers = _customerRepository.GetAll();
             foreach (var customer in customers)
                _customers.Add(customer);
          }
    
          private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
          public ObservableCollection<Customer> Customers
          {
             get { return _customers; }
             private set { _customers = value; }
          }
    
          private ObservableCollection<Product> _products = new ObservableCollection<Product>();
          public ObservableCollection<Product> Products
          {
             get { return _products; }
             private set { _products = value; }
          }
    
          private Customer _selectedCustomer;
          public Customer SelectedCustomer
          {
             get { return _selectedCustomer; }
             set
             {
                _selectedCustomer = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCustomer"));
                BuildProductsCollectionByCustomer();
             }
          }
          private Product _selectedProduct;
          public Product SelectedProduct
          {
             get { return _selectedProduct; }
             set
             {
                _selectedProduct = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedProduct"));
                DoSomethingWhenSelectedPropertyIsSet();
             }
          }
          private void DoSomethingWhenSelectedPropertyIsSet()
          {
             // elided
          }
    
          private void BuildProductsCollectionByCustomer()
          {
             var productsForCustomer = _productRepository.GetById(_selectedCustomer.Id);
             foreach (var product in Products)
             {
                _products.Add(product);
             }
          }
    
          public event PropertyChangedEventHandler PropertyChanged = delegate { };
       }
    
       public interface ICustomerRepository : IRepository<Customer>
       {
       }
    
       public class Customer
       {
          public int Id { get; set; }
       }
    
       public interface IProductRepository : IRepository<Product>
       {
       }
    
       public class Product
       {
       }
