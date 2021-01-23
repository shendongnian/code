    [HttpPost]
    public ActionResult CheckPreferences(string menuItems, string features)
	{
		var js = new JavaScriptSerializer();
		var deserializedMenuItems = (object[])js.DeserializeObject(menuItems);
		var deserializedFeatures = (object[])js.DeserializeObject(features);
		var myFeatures = new List<SJSonModel>();
		var myMenuItems = new List<SJSonModel>();
		if (deserializedFeatures != null)
		{
			foreach (Dictionary<string, object> newFeature in deserializedFeatures)
			{
				myFeatures.Add(new SJSonModel(newFeature));
			}
		}
		if (deserializedMenuItems != null)
		{
			foreach (Dictionary<string, object> newMenuItem in deserializedMenuItems)
			{
				myMenuItems.Add(new SJSonModel(newMenuItem));
			}
		}
		var myModelList = new SJSonModelList(myFeatures, myMenuItems);
		return Json("");
