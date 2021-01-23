     public class LVItemModel
     {
         public int Id { get; set; }
         public int Quantity { get; set; } 
     }
            ...
            string items = c.Value;
            if (items.Length > 0)
            {
                List<LVItemModel> list = new List<LVItemModel>();
                string[] orders = items.Split( new char[] { ':' } );
                foreach( string s in orders){
                    string[] proc = s.Split(new char { 'x' });
                    int id    = int.Parse(proc[0]);
                    int quant = int.Parse(proc[1]);
                    list.Add( new LVItemModel() { Id = id, Quantity = quant } );
                }
                ListView1.DataSource = list;
                ListView1.DataBind();
            }
