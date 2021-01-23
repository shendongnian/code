        [IgnoreNamespace]
    internal class Helper
    { 
        public static void Log(string str)
        {
            var content = jQuery.Select(Helper.HTMLMessageDivSelector).GetHtml();
            var messageDiv = jQuery.Select(Helper.HTMLMessageDivSelector);
            messageDiv.Html(str + "<br/>" + content);
            //write message to debug console if it is defined
            dynamic w = System.Html.Window.Self;
            { 
                    if (w.console is object)   
                        w.console.log(str);
            }
        }
     }
