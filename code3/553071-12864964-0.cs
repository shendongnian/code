    //Controller
    public JsonResult GetSlickGridData()
    {
            var slickGridData = db.SlickGridData.ToList();
            return Json(slickGridData, JsonRequestBehavior.AllowGet);
    }
    //View
    var data = [];
    $.getJSON("/Index/GetSlickGridData", function (items) {
    data = items;
    });
    grid = new Slick.Grid("#myGrid", data, columns, options);
