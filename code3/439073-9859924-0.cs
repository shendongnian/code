    HttpContext.Current.Response.Write(
        serializer.Serialize(
            system.OrderByDescending(s => s.SYSTEM_ID).Select(s => new {
                s.SYSTEM_ID,
                NewProperty = "Foo"
    })));
