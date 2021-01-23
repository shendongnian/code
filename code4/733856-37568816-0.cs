    	    string cssClasses = "hide";
			object viewData = new { @class = cssClasses };
			dynamic expandoData = new ExpandoObject();
            var processedData = expandoData as IDictionary<String, object>;
            if (viewData != null)
            {
                PropertyInfo[] properties = viewData.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    if (prop == null) continue;
                    object valueObj = viewData .GetType().GetProperty(prop.Name).GetValue(viewData , null);
                    processedData[prop.Name.ToString()] = valueObj;
                }
            }           
            processedData["AdditionalPropertyName"] = AdditionalProperty;
			var infoJson = JsonConvert.SerializeObject(processedData);
