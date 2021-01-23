    @Html.CustomHtmlTag(Model, x => { 
                                        Model.Add("One"); 
                                        Model.Add("Two");
                                        Model.Add("Three");
                                        Model.Add("Four");
                                    }).Render()
