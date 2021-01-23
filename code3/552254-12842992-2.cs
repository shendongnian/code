    [HttpGet]
    ActionResult GetSomeOfMyType( )
    {
        ...
        HttpContext.Response.AppendHeader("your_header_name", "your_header_value");
        ...
        return new ContentResult { 
            Content = YourSerializationFunction(new MyType[ 10 ]), 
            ContentEncoding = your_encoding, // optional
            ContentType = "your_content_type" // optional
        };
    }
