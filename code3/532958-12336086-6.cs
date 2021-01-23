    public override void WriteJson(JsonWriter writer, object value,
        JsonSerializer serializer)
    {
        if (CanConvert(value.GetType()))
        {
            var response = (MyResponse)value;
            dynamic fake = new System.Dynamic.ExpandoObject();
            fake.blog = response.blog;
            fake.posts = response.posts;
            serializer.Serialize(writer, fake);
        }
    }
