    using System;
    using System.Data;
    // and all the others ...
    namespace WebApplication1
    {
      public partial class SqlConnectionDemo : System.Web.UI.Page
      {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=AZUES-221\\JDOESQLSERVER; Initial Catalog=Northwind; Integrated Security=SSPI");
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn); 
                rdr = cmd.ExecuteReader(); // get query results
                
                while (rdr.Read()) //prints out whatever was
                { 
                    System.Diagnostics.Debug.WriteLine(rdr[0]); // or on the other hand
                    lblOutput.Text += rdr[0];   // as a "quick and dirty" solution!
                }
            }
            finally
            {
                if (rdr != null)// closes
                { rdr.Close(); }// the reader
                if (conn != null)//closes
                { conn.Close(); }// the connection
            }
        }
      }
    }
