        bool hasCustomer = false ;
        JsonSerializer s = new JsonSerializer() {
            NullValueHandling = NullValueHandling.Ignore
        };
        JObject j = JObject.FromObject( new {
            customer = hasCustomer ? new {
                name = "mike" ,
                age = 48
            } : null
        }, s );
        JObject c = (JObject)j[ "customer" ];
