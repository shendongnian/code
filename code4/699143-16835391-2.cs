    public JsonResult GetDataAssets() {
            List<object> data = new List<object>();
            data.Add(new[] { "Day", "Kasse", "Bonds", "Stocks", "Futures", "Options" });
            data.Add(new[] { 01.03, 200, 500, 100, 0, 10 });
            data.Add(new[] { 01.03, 300, 450, 150, 50, 30 });
            data.Add(new[] { 12.15, 350, 200, 180, 80, 40 });
            return Json(data);
        }
