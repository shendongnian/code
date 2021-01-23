    public static List<Foo> FromJson(string input) {
        var json = JToken.Parse(input);
        json["key"].Remove();
        var foo = JsonConvert.DeserializeObject<List<Foo>>(json.ToString());
    }
