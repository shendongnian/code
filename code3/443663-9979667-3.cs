    [HttpPost]
    public ActionResult MyAction(FormCollection values)
    {
        var jsonArray = values["myArray"];
        var deserializer = new JavaScriptSerializer();
        var cSharpArray = deserializer.Deserialize<List<string>>(jsonArray);
        //Here you will handle your array as you wish
        //Finally you could pass a string to send a message to your form
        return Content("Message to user");
    }
