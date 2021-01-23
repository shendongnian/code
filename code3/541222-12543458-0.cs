    string json = @"{""Name"":""Joe"",
                     ""Age"":30,
                     ""Address"":{ ""City"":""NY"" }}";
    dynamic dynObj = new DynamicJson(json);
    Console.WriteLine(dynObj.Name);
    Console.WriteLine(dynObj.Age);
    Console.WriteLine(dynObj.Address.City);
--
    public class DynamicJson : DynamicObject
    {
        Dictionary<string, object> _Dict;
        public DynamicJson(string json)
        {
            _Dict = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(json); 
        }
        DynamicJson(Dictionary<string, object> dict)
        {
            _Dict = dict;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            object obj;
            if (!_Dict.TryGetValue(binder.Name, out obj)) return false;
            if (obj is Dictionary<string, object>)
            {
                result = new DynamicJson((Dictionary<string, object>)obj);
            }else
            {
                result = obj;
            }
            return true;
        }
    }
