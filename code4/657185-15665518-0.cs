    ...
        public static class JSONHelper
        {
            public static string ToJSONString(this object obj)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(obj);
            }
        }
    ...
    
        public ObjChild1
        {
            public string name {get;set;}
    
            [ScriptIgnore]
            public string JsonSource { get { return this.ToJSONString(); } }
        }    
    
        public class ObjChild2
        {
            public int age {get;set;}
        
            [ScriptIgnore]
            public string JsonSource { get { return this.ToJSONString(); } }
        }
