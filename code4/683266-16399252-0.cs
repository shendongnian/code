    var list = jObj.Children()
                .Cast<JProperty>()
                .Select(p => new FromDic()
                {
                    Name = p.Name,
                    Attr1 = (string)p.Value["P1"],
                    Attr2 = (string)p.Value["P2"]
                })
                .ToList();
---
    public class FromDic
    {
        public string Name;
        public string Attr1;
        public string Attr2;
    }
