    @{
                        bool vals = false;
                        var dictionaryObj = new Dictionary<string, object>();
                        dictionaryObj.Add("id", "goodId");
                        dictionaryObj.Add("class", "sadd");
                        if(vals){
                            dictionaryObj.Add("checked", "checked");   
                        }
                    }
                     @Html.RadioButtonFor(x => x.Status, "Good",dictionaryObj) Good
