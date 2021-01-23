    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TestApp.Models;
    
    namespace TestApp.Controllers {
    
        public class HomeController : Controller {
    
            public ActionResult Index() {
                return RedirectToAction("Test");
            }
    
            public ActionResult Test() {
                var model = new EmployeeViewModel();
                return View(model);
            }
    
            [HttpPost]
            public ActionResult Test(EmployeeViewModel model) {
    			// Force an error on this property - THIS should be the only real error that gets returned back to the view
                ModelState.AddModelError("", "Error on First Name");
    			
                if(model.EmailAddress == null) // Add an INFO message
                    ModelState.AddModelError("", "Email Address Info");
                if (model.Username == null) // Add another INFO message
                    ModelState.AddModelError("", "Username Info");
    				
                // Get the Real error off the ModelState
                var errors = GetRealErrors(ModelState);
    			
    			// clear out anything that the ModelState currently has in it's Errors collection
                foreach (var modelValue in ModelState.Values) {
                    modelValue.Errors.Clear();
                }
    			// Add the real errors back on to the ModelState
                foreach (var realError in errors) {
                    ModelState.AddModelError("", realError.ErrorMessage);
                }
                return View(model);
            }
    
            private IEnumerable<ModelError> GetRealErrors(IEnumerable<KeyValuePair<string, ModelState>> modelStateDictionary) {
                var errorMessages = new List<ModelError>() ;
                foreach (var keyValuePair in modelStateDictionary) {
                    if (keyValuePair.Value.Errors.Count > 0) {
                        foreach (var error in keyValuePair.Value.Errors) {
                            if (!error.ErrorMessage.Contains("Info")) {
                                errorMessages.Add(error);
                            }
                        }
                    }
    
                }
                return errorMessages;
            }
        }
    }
