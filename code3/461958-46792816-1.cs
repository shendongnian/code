            [HttpGet]
            public IActionResult TestJSON()
            {
                var obj = new Thing
                {
                    id = 1,
                    reference = new Thing
                    {
                        id = 2,
                        reference = new Thing
                        {
                            id = 3,
                            reference = new Thing
                            {
                                id = 4
                            }
                        }
                    }
                };
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new ShouldSerializeContractResolver(2),
                };
    
                return new JsonResult(obj, settings);
    
            }
