    namespace X.Controllers
    {
        public class NotificationsController : ApiController
        {
            public List<Node> getNotifications(int id)
            {
                var bo = new HomeBO();
                var list = bo.GetNotificationsForUser(id);
                var notificationTreeNodes = (from GBLNotifications n in list
                                             where n.NotificationCount != 0
                                             select new NotificationTreeNode(n)).ToList();
                var li = notificationTreeNodes.Select(no => new Node
                {
                        notificationType = no.NotificationNode.NotificationType + " " + "(" + no.NotificationNode.NotificationCount + ")", notifications = bo.GetNotificationsForUser(id, no.NotificationNode.NotificationTypeId).Cast<GBLNotifications>().Select(item => new Notification
                        {
                                ID = item.NotificationId, NotificationDesc = item.NotificationDescription
                        }).ToList()
                }).ToList();
                return li;
            }
        }
    
        public class Node
        {
            public List<Notification> notifications;
    
            public string notificationType
            {
                get;
                set;
            }
        }
    
        public class Notification
        {
            public int ID
            {
                get;
                set;
            }
    
            public string NotificationDesc
            {
                get;
                set;
            }
        }
    }
