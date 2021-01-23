        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Mvc;
        using System.Web.Security;
        using Mail.Models;
        
        namespace Mail.Controllers
        {
            public class SubscriberGroupController : Controller
            {
                private int groupID;
                private MailDBEntities db = new MailDBEntities();
                //
                // GET: /SubscriberGroup/
        
                public ActionResult Index(int id)
                {
                    groupID = id;
                    MembershipUser myObject = Membership.GetUser();
                    Guid UserID = Guid.Parse(myObject.ProviderUserKey.ToString());
                    UserCustomer usercustomer = db.UserCustomers.Single(s => s.UserID == UserID);
                    var subscribers = from subscriber in db.Subscribers
                                      where (subscriber.CustomerID == usercustomer.CustomerID) | (subscriber.CustomerID == 0)
                                      select new SubscriberCheckedModel { subscriber = subscriber, AddToGroup = false };
                    SubscriberCheckedListViewModel test = new SubscriberCheckedListViewModel();
                    test.subscribers = subscribers;
    test.GroupId=groupID;
                    return View(test);
                }
        
        
        
                [HttpPost]
                public ActionResult Index(string filter)
                {
                    MembershipUser myObject = Membership.GetUser();
                    Guid UserID = Guid.Parse(myObject.ProviderUserKey.ToString());
                    UserCustomer usercustomer = db.UserCustomers.Single(s => s.UserID == UserID);
                    var subscribers2 = from subscriber in db.Subscribers
                                       where ((subscriber.FirstName.Contains(filter)|| subscriber.LastName.Contains(filter))
                                       && (subscriber.CustomerID == usercustomer.CustomerID || subscriber.CustomerID == 0))
                                       select new SubscriberCheckedModel { subscriber = subscriber, AddToGroup = false };
                    SubscriberCheckedListViewModel test = new SubscriberCheckedListViewModel();
                    test.subscribers = subscribers2.ToList();
                    return View(test);
                }
        
                [HttpPost]
                public ActionResult AddToGroup(SubscriberCheckedListViewModel test)
                {
                    var id=test.GroupId; 
                    return RedirectToAction("Details", "Group", new { id = groupID });
                }
        
        
            }
