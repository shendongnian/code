    JObject j = JObject.FromObject(new
            {
                customer = hasCustomer? new
                {
                    name = "mike",
                    age = 48
                }:new Object()
            });
