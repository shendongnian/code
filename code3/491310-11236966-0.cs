    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;
    namespace UserDetails.Controllers
    {
    public class HomeController : Controller
    {
        private readonly List<Employee> m_employees;
        public HomeController()
        {
            m_employees = new List<Employee>
                              {
                                  new Employee
                                      {
                                          Id =  Guid.Parse("3aebbf53-3581-4822-bef4-c9701d927b93"),
                                          JobTitle = "Senior Developer",
                                          Manager = "Mr. Smith",
                                          Salary = 1500
                                      },
                                      
                                    new Employee
                                        {
                                            Id= Guid.Parse("{3924afa7-d31b-4d30-b368-f825d4028779}"),
                                            JobTitle = "Lead Developer",
                                            Manager= "Mr. Doe",
                                            Salary = 2500
                                        }
                              };
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                
                if (currentUser != null && currentUser.ProviderUserKey != null && currentUser.IsApproved)
                {
                    var currentUserId = (Guid)currentUser.ProviderUserKey;
                    Employee result = (from employee in m_employees
                                       where employee.Id == currentUserId
                                       select employee).FirstOrDefault();
                    return View(result);
                }
            }
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
    public class Employee
    {
        public Guid Id { get; set; }
        public string JobTitle { get; set; }
        public string Manager { get; set; }
        public int Salary { get; set; }
    }
    }
