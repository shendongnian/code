    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public JgGrid SearchGrid(int rows, int page, string sidx, string sord,string filters)
        {
            AdvWorksDataContext dc = new AdvWorksDataContext();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            filters f = serializer.Deserialize<filters>(filters);
            
            var p = dc.vProductAndDescriptions.AsQueryable();
            if (f.groupOp == "AND")
                foreach (var rule in f.rules)
                    p = p.Where<vProductAndDescription>(
                        rule.field, rule.data,
                        (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op)
                        );
            else
            { 
                //Or
                var temp = (new List<vProductAndDescription>()).AsQueryable();
                foreach (var rule in f.rules)
                {
                    var t = p.Where<vProductAndDescription>(
                        rule.field, rule.data,
                        (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op)
                        );
                    temp = temp.Concat<vProductAndDescription>(t);
                }
                p = temp;
            }
            p = p.OrderBy<vProductAndDescription>(sidx, sord);
            return new JgGrid(page, p, rows);
        }
    }
