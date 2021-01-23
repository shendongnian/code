    // Create a view model that fit your needs
    public class PasswordRecoveryViewModel {
        public string StudentID { get; set; }
        // Other properties as needed
    }
    
    // Do something like this in your action
    public ActionResult YourAction () {
        var model = new PasswordRecoveryViewModel {
            StudentId = "1"; // Assign the ID as needed
        }    
        return View(model);
    }
