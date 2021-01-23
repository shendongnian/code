    using System;
    using System.Xml;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    public partial class _Default : System.Web.UI.Page
    {
        string org_id;
        string org_desig;
        string org_name;
        string add_1;
        string add_2;
        string add_3;
        string cityname;
        string countrycode;
        string countryname;
        string postalcode;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //  Load the XML file
            XmlTextReader reader = new XmlTextReader("PXMLF-8612013050420130606105906.xml");
            //  Loop over the XML file
            while (reader.Read())
            {
                //  look for element
                if (reader.NodeType == XmlNodeType.Element)
                {
                    //  If the element is the one required
                    switch (reader.Name)
                    {
                        case "OrganizationID":
                            org_id = (reader.ReadElementString());
                            break;
                        case "OrganisationDesignator":
                            org_desig = (reader.ReadElementString());
                            break;
                        case "OrganizationName1":
                            org_name = (reader.ReadElementString());
                            break;
                        case "AddressLine1":
                            add_1 = (reader.ReadElementString());
                            break;
                        case "AddressLine2":
                            add_2 = (reader.ReadElementString());
                            break;
                        case "AddressLine3":
                            add_3 = (reader.ReadElementString());
                            break;
                        case "CityName":
                            cityname = (reader.ReadElementString());
                            break;
                        case "CountryCode":
                            countrycode = (reader.ReadElementString());
                            break;
                        case "CountryName":
                            countryname = (reader.ReadElementString());
                            break;
                        case "PostalCode":
                            postalcode = (reader.ReadElementString());
                            break; 
                    }
                }
            }
            //connect to db
            string connStr = ConfigurationManager.ConnectionStrings["connXML"].ConnectionString;
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            //send extracted data to db
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into INV_HEADER VALUES ('" + org_id + "','" + org_desig + "', '" + org_name +
                              "' , '" + add_1 + "', '" + add_2 + "', '" + add_3 + "', '" + cityname + "', '" +
                              countrycode + "', '" + countryname + "', '" + postalcode + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            reader.Close();
        }
    }
