    namespace MvcHelpers.Helpers
    {
        public class ButtonHelper
        {
            public static MvcHtmlString SpecialButton(string id)
            {
              return new MvcHtmlString(String.Format("<input id=\"{0}\" type=\"button\" value=\"Special\"/>", id));
            }
        }
    }
