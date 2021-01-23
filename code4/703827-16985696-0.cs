    public JsonResult GetDataList(int? assetId)
    {
        var tableData = DBData.ToList();
        return Json(new {
            aaData = ???
        },
        "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
    }
