    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Xml.Serialization;
    class Program
    {
        static void Main(string[] args)
        {
            var cs = "YourConnectionString";
            var xml = "";
            using (var con = new SqlConnection(cs))
            using (var c = new SqlCommand("SELECT * FROM CandidateApplication", con))
            {
                con.Open();
                using (var adapter = new SqlDataAdapter(c))
                {
                    var ds = new DataSet("CandidateApplications");
                    ds.Tables.Add("CandidateApplication");
                    adapter.Fill(ds, ds.Tables[0].TableName);
                    xml = ds.GetXml();
                }
            }
            // We need to specify the root element
            var rootAttribute = new XmlRootAttribute();
            // The class to use as the XML root element (should match the name of 
            // the DataTable in the DataSet above)
            rootAttribute.ElementName = "CandidateApplications";
            // Initializes a new instance of the XmlSerializer class that can 
            // serialize objects of the specified type into XML documents, and 
            // deserialize an XML document into object of the specified type. 
            // It also specifies the class to use as the XML root element.
            // I chose List<CandidateApplication> as the type because I find it
            // easier to work with (but CandidateApplication[] will also work)
            var xs = new XmlSerializer(typeof(List<CandidateApplication>), rootAttribute);
            // Deserialize the XML document contained by the specified TextReader, 
            // in our case, a StringReader instance constructed with xml as a parameter.
            List<CandidateApplication> results = xs.Deserialize(new StringReader(xml));
        }
    }
