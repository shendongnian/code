     // if (textBox1.Text.Length >= 1)
        //    {
                string w = Web.get("MY JSON API URL");
    
                JObject o = JObject.Parse(w);
                List<string> ac = new List<string>();
                foreach (JObject item in o["items"])
                {
                    string name = item["name"].ToString();
                    ac.Add(name);
                }
                colValues.AddRange(ac.ToArray());
       //     }
