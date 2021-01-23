    using System;
    using Microsoft.VisualBasic;
    using System.Text;
    using System.Collections;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    /// <summary>
    /// Summary description for WebMsgBox
    /// </summary>
    
    public class WebMsgBox
    {
    
        protected static Hashtable handlerPages = new Hashtable();
    
        protected static string redirectUrl = "";
    
        private WebMsgBox()
        {
    
        }
    
    
        public static void Show(string Message, string redirectUrl = "")
        {
    
            if (!(handlerPages.Contains(HttpContext.Current.Handler)))
            {
    
                Page currentPage = (Page)HttpContext.Current.Handler;
    
                if (!((currentPage == null)))
                {
                    if (!string.IsNullOrWhiteSpace(redirectUrl))
                        WebMsgBox.redirectUrl = redirectUrl;
    
                    Queue messageQueue = new Queue();
    
                    messageQueue.Enqueue(Message);
    
                    handlerPages.Add(HttpContext.Current.Handler, messageQueue);
    
                    currentPage.Unload += new EventHandler(CurrentPageUnload);
    
                }
    
            }
    
            else
            {
    
                Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
    
                queue.Enqueue(Message);
    
            }
    
        }
    
    
    
        private static void CurrentPageUnload(object sender, EventArgs e)
        {
    
            Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
    
            if (queue != null)
            {
    
                StringBuilder builder = new StringBuilder();
    
                int iMsgCount = queue.Count;
    
                builder.Append("<script language='javascript'>");
    
                string sMsg;
    
                while ((iMsgCount > 0))
                {
    
                    iMsgCount = iMsgCount - 1;
    
                    sMsg = System.Convert.ToString(queue.Dequeue());
    
                    sMsg = sMsg.Replace("\"", "'");
    
                    builder.Append("alert( \"" + sMsg + "\" );");
    
                }
    
                if (!string.IsNullOrWhiteSpace(WebMsgBox.redirectUrl))
                    builder.Append("window.location = '" + WebMsgBox.redirectUrl + "'");
    
                builder.Append("</script>");
    
                handlerPages.Remove(HttpContext.Current.Handler);
    
                HttpContext.Current.Response.Write(builder.ToString());
    
            }
    
        }
    
    }
