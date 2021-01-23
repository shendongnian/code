    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)   //Upload file here
            {
                string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);  //Get extension
                if (fileExt == ".csv")   //check to see if its a .csv file
                {
                    FileUpload1.SaveAs("C:\\FolderName\\" + FileUpload1.FileName);        //save file to the specified folder
                    OleDbConnection oconn = new     OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\AudioPRFiles\\; Extended     Properties='text; HDR=Yes; FMT=Delimited'");   //string connection for .CSV     OR Text file
                    try
                    {
                        OleDbCommand ocmd = new OleDbCommand("SELECT * FROM [" +     FileUpload1.FileName + "]", oconn);    //Select statement, if your using .CSV...put the name of the file NOT the excel tab
                   
                    oconn.Open();
                    OleDbDataReader odr = ocmd.ExecuteReader();  
                    string Device = "";
                    string Source = "";
                    string Reviewer = "";
                    string Datetime = "";
                    string Links = "";
                    string Content = "";
                    string Subject = "";
                    while(odr.Read())
                    {
                        Device = valid(odr, 0);     //Call the valid method...see below
                        Source = valid(odr, 1);
                        Reviewer = valid(odr, 2);
                        Datetime = valid(odr, 3);
                        Links = valid(odr, 4);
                        Content = valid(odr, 5);
                        Subject = valid(odr, 6);
                        InsertDataIntoSql(Device, Source, Reviewer, Datetime, Links, Content, Subject);  //Call the InsertDataIntoSql method...see below
                        FileUpload1.Dispose();  //Dispose the file
                        
                    }
                    oconn.Close();   //Close connection
                }
                catch (Exception ee)
                {
                    Label1.Text = ee.Message;
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                    Label1.Text = "Data Inserted Successfully";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                Label1.Text = "Only .csv files allowed!";
            }
        }
        else
        {
            Label1.Text = "You have not specified a file!";
        }    
     }
    protected string valid(OleDbDataReader myreader, int stval)  //this method checks for null values in the .CSV file, if there are null replace them with 0
    {
        object val = myreader[stval];
        if (val != DBNull.Value)
        {
            return val.ToString();
        }
        else
        {
            return Convert.ToString(0);
        }
    
    }
    public void InsertDataIntoSql(string Device, string Source, string Reviewer, string Datetime, string Links, string Content, string Subject) //method to insert data into database
    {
        SqlConnection conn = new SqlConnection("Server=ServerAddress; Database=MyDatabaseName; Trusted_Connection=True");                        //SQL connection
        SqlCommand cmd = new SqlCommand();                           //SQL command
        cmd.Connection = conn;
        cmd.CommandText = "USE [MyDataBase] INSERT INTO Table_Name(Device, Source, Reviewer, Datetime, Links, Content, Subject) VALUES(@Device, @Source, @Reviewer, @Datetime, @Links, @Content, @Subject)";
        cmd.Parameters.Add("@Device", System.Data.SqlDbType.Int).Value = Device;
        cmd.Parameters.Add("@Source", System.Data.SqlDbType.NVarChar).Value = Source;
        cmd.Parameters.Add("@Reviewer", System.Data.SqlDbType.NVarChar).Value = Reviewer;
        cmd.Parameters.Add("@Datetime", System.Data.SqlDbType.Date).Value = Datetime;
        cmd.Parameters.Add("@Links", System.Data.SqlDbType.NVarChar).Value = Links;
        cmd.Parameters.Add("@Content", System.Data.SqlDbType.NVarChar).Value = Content;
        cmd.Parameters.Add("@Subject", System.Data.SqlDbType.NVarChar).Value = Subject;
        cmd.CommandType = System.Data.CommandType.Text;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    
       }
    }
    Hope this helps..Thanks
