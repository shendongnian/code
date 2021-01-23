    public class NameValue
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class Lead
    {
        public NameValue assigned_user_name { get; set; }
        public NameValue modified_by_name { get; set; }
        public NameValue created_by_name { get; set; }
    }
    public class LeadRequest
    {
        public Lead name_value_list { get; set; }
    }
    public void JsonTest()
    {
        var req = new LeadRequest
            {
                name_value_list = new Lead
                    {
                        assigned_user_name = new NameValue {name = "assigned_user_name", value = "joe"},
                        modified_by_name = new NameValue {name = "modified_by_name", value = "jill"},
                        created_by_name = new NameValue {name = "created_by_name", value = "jack"}
                    }
            };
            var jsonReq  = ServiceStack.Text.JsonSerializer.SerializeToString(req);
    }
