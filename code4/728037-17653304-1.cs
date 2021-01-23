    [HttpPost]
    public JsonResult testGetUser(long userNo)
    {
        userData result = new userData();
        result.firstName = Session["firstName"].ToString();
        result.lastName = Session["lastName"].ToString();
        result.state = Session["country"].ToString();
        result.success = true;
        return Json(result);
    }
