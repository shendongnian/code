    public sealed class UIHelper
    {
        public static string GetThatValue()
        {
            return (string)HttpContext.Current.Session["target_key"];
        }
    }
