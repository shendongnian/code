		public string ToJson()
		{
			JObject json = new JObject();
			JObject aps = new JObject();
			if (!this.Alert.IsEmpty)
			{
				if (!string.IsNullOrEmpty(this.Alert.Body)
					&& string.IsNullOrEmpty(this.Alert.LocalizedKey)
					&& string.IsNullOrEmpty(this.Alert.ActionLocalizedKey)
					&& (this.Alert.LocalizedArgs == null || this.Alert.LocalizedArgs.Count <= 0)
					&& !this.HideActionButton)
				{
					aps["alert"] = new JValue(this.Alert.Body);
				}
				else
				{
					JObject jsonAlert = new JObject();
					if (!string.IsNullOrEmpty(this.Alert.LocalizedKey))
						jsonAlert["loc-key"] = new JValue(this.Alert.LocalizedKey);
					if (this.Alert.LocalizedArgs != null && this.Alert.LocalizedArgs.Count > 0)
						jsonAlert["loc-args"] = new JArray(this.Alert.LocalizedArgs.ToArray());
					if (!string.IsNullOrEmpty(this.Alert.Body))
						jsonAlert["body"] = new JValue(this.Alert.Body);
					if (this.HideActionButton)
						jsonAlert["action-loc-key"] = new JValue((string)null);
					else if (!string.IsNullOrEmpty(this.Alert.ActionLocalizedKey))
						jsonAlert["action-loc-key"] = new JValue(this.Alert.ActionLocalizedKey);
					aps["alert"] = jsonAlert;
				}
			}
			if (this.Badge.HasValue)
				aps["badge"] = new JValue(this.Badge.Value);
			if (!string.IsNullOrEmpty(this.Sound))
				aps["sound"] = new JValue(this.Sound);
			if (this.ContentAvailable.HasValue)
				aps["content-available"] = new JValue(this.ContentAvailable.Value);
			//json["aps"] = aps;
			foreach (string key in this.CustomItems.Keys)
			{
				if (this.CustomItems[key].Length == 1)
					json[key] = new JValue(this.CustomItems[key][0]);
				else if (this.CustomItems[key].Length > 1)
					json[key] = new JArray(this.CustomItems[key]);
			}
			string rawString = json.ToString(Newtonsoft.Json.Formatting.None, null);
			StringBuilder encodedString = new StringBuilder();
			foreach (char c in rawString)
			{
				if ((int)c < 32 || (int)c > 127)
					encodedString.Append("\\u" + String.Format("{0:x4}", Convert.ToUInt32(c)));
				else
					encodedString.Append(c);
			}
			return rawString;// encodedString.ToString();
		}
