    public class Model
    {
    public Model() {
      Status = new List<SelectListItem>();
      Status.Add(new SelectListItem { Text = "New", Value = "New" });
      Status.Add(new SelectListItem { Text = "PaymentPending", Value = "PaymentPending" });
      Status.Add(new SelectListItem { Text = "PaymentProcessed", Value = "PaymentProcessed" });
      Status.Add(new SelectListItem { Text = "Dispatched", Value = "Dispatched" });
      Status.Add(new SelectListItem { Text = "Complete", Value = "Complete" });
      Status.Add(new SelectListItem { Text = "Cancelled", Value = "Cancelled" });
    }
    public List<SelectListItem> Status { get; set; }
    public string SelectedVal{get;set;}
    } 
