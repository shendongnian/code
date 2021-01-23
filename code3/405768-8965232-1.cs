     @using Telerik.Web.Mvc.UI
     @{
       ViewBag.Title = "Home Page";
       Html.Telerik().StyleSheetRegistrar().DefaultGroup(group => group.Add("~/Content/Site2.css"));
       Html.Telerik().ScriptRegistrar().DefaultGroup(group => group.Add("~/Scripts/Test.js"));
      }
      <h2>@ViewBag.Title</h2>
      <p>
         Bla bla bla
      </p>
