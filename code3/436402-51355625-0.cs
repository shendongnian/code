        using System;
        using System.Collections.Generic;
        using System.Configuration;
        using System.Data.SqlClient;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        
        namespace WindowsFormsApplication1
        {
            class ConnectionManager
            {
                public static SqlConnection getConnection()
                {
                    try {
                        String conn = ConfigurationManager.ConnectionStrings["Test"].ToString();
                        SqlConnection sc = new SqlConnection(conn);
                        return sc;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return null;
                    }
                }
            }
        }
    
    
     private DataTable getData()
            {
                try
                {
                    SqlConnection conn = ConnectionManager.getConnection();
                    conn.Open();
                    String sql = "SELECT * FROM Appliance_Manufacturers";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
    
            private bool addManufacture(String name)
            {
    
                try
                {
                    SqlConnection con = ConnectionManager.getConnection();
                    con.Open();
                    string query = "INSERT INTO Appliance_Manufacturers (Manufacturer) VALUES('" + name + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int status = cmd.ExecuteNonQuery();
                    con.Close();
                    return (status == 1);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
