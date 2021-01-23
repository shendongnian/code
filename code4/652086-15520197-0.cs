    // Object
    public class MyObject
    {
        public int ID { get; set; }
        public string Text { get; set; }
    }
    
    // Controller Action
    public virtual ActionResult Upload(HttpPostedFileBase file)
    {
        return this.Json(new MyObject(), "text/plain");
    }
    
    // Javascript Handler
    function onSuccess(e) {
        var response = jQuery.parseJSON(e.XMLHttpRequest.responseText);
        var id = response.ID;
        var text = response.Text;
    }
