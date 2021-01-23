<appSettings>
    <add key="reCaptchaSiteKey" value="site_key" />
    <add key="reCaptchaSecretKey" value="secret_key" />
</appSettings>
 5. In the "Models" folder, create a new class "ReCaptchaForm.cs" and copy/paste the following lines of code.
namespace ASPNetMVCWithReCaptcha3.Models
{
    public class ReCaptchaForm
    {
        public string Message { get; set; }
    }
}
 6. Create a new "Classes" folder in the project.
 7. In the "Classes" folder, create a new class "ReCaptcha.cs" and copy/paste the following lines of code:
C#
using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using System.Configuration;
namespace ASPNetMVCWithReCaptcha3.Classes
{
}
 8. Add the following lines inside the namespace 
- Add a class "GoogleReCaptchaVariables" that will store variables needed to render ReCaptcha.
C#
public static class GoogleReCaptchaVariables
{
     public static string ReCaptchaSiteKey = ConfigurationManager.AppSettings["reCaptchaSiteKey"]?.ToString() ?? string.Empty;
     public static string ReCaptchaSecretKey = ConfigurationManager.AppSettings["reCaptchaSecretKey"]?.ToString() ?? string.Empty;
     public static string InputName = "g-recaptcha-response";
}
- Create a helper class to render hidden input for response token.
C#
public static class ReCaptchaHelper
{
     public static IHtmlString ReCaptchaHidden(this HtmlHelper helper)
     {
          var mvcHtmlString = new TagBuilder("input")
          {
               Attributes =
               {
                    new KeyValuePair<string, string>("type", "hidden"),
                    new KeyValuePair<string, string>
                           ("id", GoogleReCaptchaVariables.InputName),
                    new KeyValuePair<string, string>
                           ("name", GoogleReCaptchaVariables.InputName)
               }
          };
          string renderedReCaptchaInput = 
                   mvcHtmlString.ToString(TagRenderMode.Normal);
          return MvcHtmlString.Create($"{renderedReCaptchaInput}");
     }
     public static IHtmlString ReCaptchaJS
             (this HtmlHelper helper, string useCase = "homepage")
     {
          string reCaptchaSiteKey = GoogleReCaptchaVariables.ReCaptchaSiteKey;
          string reCaptchaApiScript = "<script 
          src='https://www.google.com/recaptcha/api.js?render=" + 
          reCaptchaSiteKey + "'></script>;";
          string reCaptchaTokenResponseScript = "<script>
          $('form').submit(function(e) { e.preventDefault(); 
          grecaptcha.ready(function() { grecaptcha.execute('" + 
          reCaptchaSiteKey + "', {action: '" + useCase + 
          "'}).then(function(token) { $('#" + 
          GoogleReCaptchaVariables.InputName + "').val(token); 
          $('form').unbind('submit').submit(); }); }); }); </script>;";
          return MvcHtmlString.Create
                 ($"{reCaptchaApiScript}{reCaptchaTokenResponseScript}");
     }
}
- Add another helper class that renders "span" tag to display error message on failed ReCaptcha verification.
C#
public static IHtmlString ReCaptchaValidationMessage
             (this HtmlHelper helper, string errorText = null)
{
     var invalidReCaptchaObj = 
            helper.ViewContext.Controller.TempData["InvalidCaptcha"];
     var invalidReCaptcha = invalidReCaptchaObj?.ToString();
     if (string.IsNullOrWhiteSpace(invalidReCaptcha)) 
                          return MvcHtmlString.Create("");
     var buttonTag = new TagBuilder("span")
     {
          Attributes = {
               new KeyValuePair<string, string>("class", "text-danger")
          },
          InnerHtml = errorText ?? invalidReCaptcha
     };
     return MvcHtmlString.Create(buttonTag.ToString(TagRenderMode.Normal));
}
- Next, create an attribute "ValidateReCaptchaAttribute" to process the API call. Add an internal class "ResponseToken" to store response data. Then, implement a validation logic to show error message on failed verification.
C#
public class ValidateReCaptchaAttribute : ActionFilterAttribute
{
     public override void OnActionExecuting(ActionExecutingContext filterContext)
     {
          string reCaptchaToken = 
          filterContext.HttpContext.Request.Form[GoogleReCaptchaVariables.InputName];
          string reCaptchaResponse = ReCaptchaVerify(reCaptchaToken);
          ResponseToken response = new ResponseToken();
          if (reCaptchaResponse != null)
          {
               response = Newtonsoft.Json.JsonConvert.DeserializeObject
                          (reCaptchaResponse);
          }
          if (!response.Success)
          {
               AddErrorAndRedirectToGetAction(filterContext);
          }
          base.OnActionExecuting(filterContext);
     }
     public string ReCaptchaVerify(string responseToken)
     {
          const string apiAddress = 
                   "https://www.google.com/recaptcha/api/siteverify";
          string recaptchaSecretKey = GoogleReCaptchaVariables.ReCaptchaSecretKey;
          string urlToPost = $"{apiAddress}
          ?secret={recaptchaSecretKey}&response={responseToken}";
          string responseString = null;
          using (var httpClient = new HttpClient())
          {
               try
               {
                   responseString = httpClient.GetStringAsync(urlToPost).Result;
               }
               catch
               {
                   //Todo: Error handling process goes here
               }
           }
           return responseString;
      }
      private static void AddErrorAndRedirectToGetAction
      (ActionExecutingContext filterContext, string message = null)
      {
           filterContext.Controller.TempData["InvalidCaptcha"] = 
           message ?? "Invalid Captcha! The form cannot be submitted.";
           filterContext.Result = 
                 new RedirectToRouteResult(filterContext.RouteData.Values);
      }
      internal class ResponseToken
      {
           public bool Success { get; set; }
           public float Score { get; set; }
           public string Action { get; set; }
           public DateTime Challenge_TS { get; set; }
           public string HostName { get; set; }
           public List ErrorCodes { get; set; }
      }
 }
- In the controller, create a postback action that implements the [ValidateReCaptcha] attribute.
C#
[HttpPost]
[ValidateAntiForgeryToken]
[ValidateReCaptcha]
public ActionResult Index(ReCaptchaForm form)
{
     return View(form);
}
- On your controller's view, add the following lines to render the form, message input and submit bottom.
C#
@model ASPNetMVCWithReCaptcha3.Models.ReCaptchaForm
@using ASPNetMVCWithReCaptcha3.Classes;
@{
    ViewBag.Title = "ReCaptcha Form";
}
@using (Html.BeginForm())
{
     @Html.AntiForgeryToken()
     @Html.LabelFor(model => model.Message)
     @Html.TextAreaFor(model => model.Message, new { @class = "form-control" })
     @Html.ReCaptchaValidationMessage()
     @Html.ReCaptchaHidden()
     @Html.ReCaptchaJS()
     <button type="submit" class="btn btn-primary">Send Message</button>
}
 9. Build the project and make sure it is error free. As a result, the form should submit if ReCaptcha API returns a successful response. In contrast, the error message will show up on the bottom of message input if a failed response has been returned by the API.
