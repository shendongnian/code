     dynamic array = JsonConvert.DeserializeObject(result.ToString());
            foreach (var item in array)
            {
                foreach (var name in item["data"])
                {
                    Response.Write(name["name"]);
                }
            }
