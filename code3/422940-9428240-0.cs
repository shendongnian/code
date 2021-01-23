                    var anType = new
                    {
                        multiResult = new
                        {
                            results = new[]
                            {
                              new 
                              {
                                description = string.Empty,
                                title = string.Empty,
                                picUrl = string.Empty,
                                totalTime = 0,
                                outerPlayerUrl = string.Empty,
                                picChoiceUrl = new string[] { "", "" }
                              }
                            }
                        }
                    };
                    //get info from JsonString
                    var tudou = JsonConvert.DeserializeAnonymousType(jsonString, anType);
                    return VideoDetail.CreateSimpleInstance(DateTime.Now,
                        tudou.multiResult.results[0].title,
                        tudou.multiResult.results[0].description,
                        tudou.multiResult.results[0].picUrl,
                        tudou.multiResult.results[0].outerPlayerUrl);
                }
