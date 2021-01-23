    var union = imageInfo = AppConfigService.All().
       Where(a =>(a.ConfigProperty == "MaterialImages")).FirstOrDefault().
      Union(
               AppConfigService.All().Where(c => (c.ConfigProperty ==
                                            "DefaultImagePath")).FirstOrDefault());
