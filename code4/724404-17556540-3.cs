    public JsonResult BrightColourExists(BrightColourViewModel brightColour)
    {
        // Call shared code to check if colour exists
        return Json(false, JsonRequestBehavior.AllowGet);
    }
    
    public JsonResult DarkColourExists(DarkColourViewModel darkColour)
    {
        // Call shared code to check if colour exists
        return Json(false, JsonRequestBehavior.AllowGet);
    }
