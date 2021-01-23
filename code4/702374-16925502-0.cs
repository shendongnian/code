    this.SetConfig(new EndpointHostConfig {
                        AddMaxAgeForStaticMimeTypes =
                            new Dictionary<string, TimeSpan>
                                {
                                    {
                                        "image/jpeg", 
                                        TimeSpan.FromDays(7.0)
                                    },
                                    {
                                        "video/mpeg", 
                                        TimeSpan.FromDays(1.0)
                                    }, 
                                } });
