    public class MyWebPart : WebPart, IPostBackEventHandler {
        protected override void CreateChildControls() {
            Control clickable = ...; // Create a clickable control.
            // Get JavaScript expression to send postback "test" to "this" web part.
            var postBack = Page.ClientScript.GetPostBackEventReference(this, "test");
            clickable.Attributes["onclick"] = postBack + "; return false";
            Controls.Add(clickable);
        }
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument) {
            if (eventArgument == "test") { // Recognize and handle our postback.
               ...
            }
        }
    }
