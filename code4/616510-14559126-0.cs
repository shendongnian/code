        using System.Web.UI;
    
    public static class NotificationHelper
    {
        /// <summary>
        /// Shows the successful notification.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="message">The message.</param>
        public static void ShowSuccessfulNotification(this Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "notificationScript",
                                                    "<script type='text/javascript'>  $(document).ready(function () {  $.notify.success('I do not want to close by myself close me ', { close: true });});</script>");
        }
    }
