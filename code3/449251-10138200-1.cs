        [HttpPost]
		public ActionResult CreateFolder(string list)
		{
			var js = new JavaScriptSerializer();
			var deserializedObject = (object[])js.DeserializeObject(list);
			var myFolders = new List<Folder>();
			if (deserializedObject != null)
			{
				foreach (Dictionary<string, object> newFolder in deserializedObject)
				{
					myFolders.Add(new Folder(newFolder));
				}
			}
			return Json("");
		}
