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
            var rootAttribute = new XmlRootAttribute();
            rootAttribute.IsNullable = true;
            rootAttribute.ElementName = "CandidateApplications";
            var xs = new XmlSerializer(typeof(List<CandidateApplication>), rootAttribute);
            var results = xs.Deserialize(new StringReader(xml));
        }
    }
