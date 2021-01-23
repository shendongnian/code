            dynamic stuff = JsonConvert.DeserializeObject(result);
            foreach (JObject item in stuff)
            {
                foreach (JProperty trend in item["user"])
                {
                    if (trend.Name == "name")
                    {
                        MessageBox.Show(trend.Value.ToString());
                    }
                    else if (trend.Name == "followers_count")
                    {
                        // GET COUNT
                    }
                    else if (trend.Name == "profile_image_url")
                    {
                        // GET PROFILE URL
                    }
                }
            }
