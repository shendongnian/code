    public static class Pager
    {
        public static string LabelSomething(this System.Web.Mvc.HtmlHelper helper, string target , string text){
            return string.Format("<label for='{0}'>{1}</label>", target, text);
        }
    }
