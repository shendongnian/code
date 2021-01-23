    function register() {
        var userModel = {
            phoneNumber: "1236663",
            displayName: "yasuuu",
        }
    	
        $.ajax({
            type: "POST",
            url: "http://localhost:13234/Home/Register",
            data: userModel,
            success: function (response) {
                $('#deleteThisDivButNotItsContent').html(response.message)
            }
        });
    }
    
    publi class UserModel
    {
    	public string phoneNumber { get; set; }
    	public string displayName { get; set; }
    }
    
    public JsonResult Register(UserModel userModel)
    {
    	// Some working code here ...
    
    	return Json(new { message = "Some message here" }, JsonRequestBehavior.AllowGet);
    }
