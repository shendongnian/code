    using System.Collections.Generic;
    using System.Web.Routing;
    
    namespace System.Web.Mvc.Html
    {
        public static class HtmlHelperExtensions
        {
            public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItemExtends> selectList, object htmlAttributes)//, Func<object, bool> ItemDisabled)
            {
                //Creating a select element using TagBuilder class which will create a dropdown.
                TagBuilder dropdown = new TagBuilder("select");
                //Setting the name and id attribute with name parameter passed to this method.
                dropdown.Attributes.Add("name", name);
                dropdown.Attributes.Add("id", name);
    
                var options = "";
                TagBuilder option;
                //Iterated over the IEnumerable list.
                foreach (var item in selectList)
                {
                    option = new TagBuilder("option");
                    option.MergeAttribute("value", item.Value.ToString());
    
                    if (item.Enabled == false)
                        option.MergeAttribute("disabled", "disabled");
    
                    if (item.PropExtends != null)
                        option.MergeAttributes(item.PropExtends);
    
                    option.SetInnerText(item.Text);
                    options += option.ToString(TagRenderMode.Normal) + "\n";
                }
                //assigned all the options to the dropdown using innerHTML property.
                dropdown.InnerHtml = options.ToString();
                //Assigning the attributes passed as a htmlAttributes object.
                dropdown.MergeAttributes(new RouteValueDictionary(htmlAttributes));
                //Returning the entire select or dropdown control in HTMLString format.
                return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
    
            }
        }
        public class SelectListItemExtends : SelectListItem
        {
            public bool Enabled { get; set; }
            public IDictionary<string, string> PropExtends { get; set; }
        }
    }
