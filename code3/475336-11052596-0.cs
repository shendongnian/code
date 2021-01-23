    var coords = new Dictionary<int, MouseCoordinates>();
    HttpContext.Session.Add("coords", coords);
    // Accessing Dictionary From Session
    var coords = (Dictionary<int, MouseCoordinates>)HttpContext.Session["coords"];
    // Adding Values using a integer stage that's posted back to the controller
    coords.Add(currentStage, new MouseCoordinates { xposition = xpos, yposition = ypos });
    // Looping through the session at the end of the cycle
                foreach (var ords in coords)
                {
                    var qnode = ords.Key;
                    var xvalue = ords.Value.xposition;
                    var yvalue = ords.Value.yposition;
                }
   
