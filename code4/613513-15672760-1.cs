		public ActionResult ProcessCriteria(int id, Criteria criteria)
		{
			var ser = new System.Web.Script.Serialization.JavaScriptSerializer();
		    StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Request.InputStream);
		    reader.BaseStream.Position = 0;
			criteria = ser.Deserialize<Criteria>(reader.ReadToEnd());
			
			return Json(_service.ProcessCriteria(id, criteria));
		}
