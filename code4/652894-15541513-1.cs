            [HttpPost]
    		public JsonResult Action(string json)
    		{
    			dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
    			string codeSkills = data.skills.code;
    ...
