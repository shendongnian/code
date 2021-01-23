    public class AdminController : Controller
    {
       private readonly IRepository<User> _userRepository;
       private readonly IRepository<Order> _orderRepository;
       public AdminController(IRepository<User> userRepository, 
                              IRepository<Order> orderRepository)
       {
           _userRepository = userRepository;
           _orderRepository = orderRepository;
       }
       //Skip code
    }
