    // suppose your string deserialized into this structure
    var obj = new JObject(
        new JProperty("Settings.Hosts.35.Active", false),
        new JProperty("Settings.Hosts.35.MACAddress", "xx:xx:xx:xx:xx"),
        new JProperty("Settings.Hosts.37.Active", false)
    );
    
    var re = new Regex(@"^Settings\.Hosts\.(\d+)\.(\w+)$");
    var newObj = new JObject(
        new JProperty("Settings.Hosts",
            new JObject(
                from prop in obj.Cast<JProperty>()
                let m = re.Match(prop.Name)
                where m.Success
                group new JProperty(m.Groups[2].Value, prop.Value)
                    by m.Groups[1].Value into g
                select new JProperty(g.Key, new JObject(g))
            )
        )
    );
