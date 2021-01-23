    context.Response.Write(
        jsonSerializer.Serialize(
            new
            {
                Term = "My Term",
                ID = 22
            }
        )
    );
