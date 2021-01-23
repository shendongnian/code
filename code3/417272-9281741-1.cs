    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace DB02
    {
        class Program
        {
            static void Main(string[] args)
            {
                SqlConnection connection = new SqlConnection(@"server=.\sqlexpress;
                integrated security=true; database=northwind");
                try
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_return_orders_by_employeeid_and_show_order_count";
                    //SqlParameter Definition Section.
                    SqlParameter inparam = new SqlParameter("@empid", SqlDbType.Int);
                    inparam.Direction = ParameterDirection.Input;
                    inparam.Value = 2;
                    cmd.Parameters.Add(inparam);
                    SqlParameter outparam = new SqlParameter("@ordercount", SqlDbType.Int);
                    outparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outparam);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t", rdr[0].ToString(), rdr[1].ToString(),
                            rdr[9].ToString());
                    }
                    connection.Close();
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Numbers of Orders= {0}", outparam.Value);          
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                }
        }
    }
