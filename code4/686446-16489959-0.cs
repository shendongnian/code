    public partial class Payment : System.Web.UI.Page
       {
           public double total; //<< keep this one
    
           protected void Page_Load(object sender, EventArgs e)
         {
            var id = Request.Params["ID"];
            System.Data.OleDb.OleDbConnection conn;
            System.Data.OleDb.OleDbCommand cmd;
            conn = new System.Data.OleDb.OleDbConnection("--");
            cmd = new System.Data.OleDb.OleDbCommand();
            conn.Open();
            cmd.Connection = conn;
            var sql = String.Format(@"select sum(PayAmt) as total from CurePay where CureID = '{0}'", id);
            cmd.CommandText = sql;
            double total = 0; // << remove the double keyword from this line
            total = Convert.ToDouble(cmd.ExecuteScalar());
            conn.Close();
