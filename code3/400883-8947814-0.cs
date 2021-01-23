     public models.GenericPageDataModel GetGenericPageContent(string keyHero, string keyBody, string keyFooter)
            {
                try
                {
                    var pageData = new List<models.GenericPageData>
                                 {
                                     new models.GenericPageData{Key = "HeroModel",Value = GetJson("pro_Page_Section_Hero_Content")},
                                     new models.GenericPageData{Key = "BodyModel",Value = GetJson("pro_Page_Section_Body_Content")},
                                     new models.GenericPageData{Key = "FooterModel",Value = GetJson("pro_Page_Section_Footer_Content")}
                                 };
    
                    var reader = new JsonReader();
    
                    var model = new models.GenericPageDataModel();
                    foreach (var p in pageData)
                    {
                        var objList = new List<ExpandoObject>();
                        dynamic output = reader.Read(p.Value);
                        foreach (var h in output)
                        {
                            dynamic obj = new ExpandoObject();
                            foreach (dynamic o in h)
                            {
                                var item = obj as IDictionary<String, object>;
                                item[o.Key] = o.Value;
                            }
                            objList.Add(obj);
                        }
                        switch (p.Key)
                        {
                            case ("HeroModel"):
                                model.HeroModel = objList.FirstOrDefault(o => o.FirstOrDefault(i => i.Key.Equals("DisplayName")).Value.Equals(keyHero));
                                break;
                            case ("BodyModel"):
                                model.BodyModel = objList.FirstOrDefault(o => o.FirstOrDefault(i => i.Key.Equals("DisplayName")).Value.Equals(keyBody));;
                                break;
                            case ("FooterModel"):
                                model.FooterModel = objList.FirstOrDefault(o => o.FirstOrDefault(i => i.Key.Equals("DisplayName")).Value.Equals(keyFooter));;
                                break;
                            default:
                                break;
                        }
                    }
                    return model;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
