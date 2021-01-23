    @using (Html.BeginForm("ActionMethodName","ControllerName",new {id = param1, name = param2}))
    {
     ... your input, labels, textboxes and other html controls go here
    
     <input class="button" id="submit" type="submit" value="Submit" />
    
    }
    public ActionResult ActionMethodName(string id,string name)
    {
     string myId = id;
     string myName = name;
    
    }
