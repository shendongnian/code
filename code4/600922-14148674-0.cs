    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using RestSharp;
    using System.Web.Script.Serialization;
    using System.IO;
    using System.Net;
    
    namespace RonRestClient
    {    
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                string path = @"C:\filename2.pdf";
                //localhost settings
                string requestHost = @"http://localhost:3000/receipts";
                string tagnr = "p94tt7w";
                string machinenr = "2803433";
                string safe_token = "123";
    
                // Do it with RestSharp
    
                templateRequest req = new templateRequest();
                req.receipt = new templateRequest.Receipt(tagnr);
                req.machine = new templateRequest.Machine(machinenr, safe_token);
    
                var request = new RestRequest("/receipts", Method.POST);
                request.AddParameter("receipt[tag_number]", tagnr);
                request.AddParameter("receipt[ispaperduplicate]", 0);
                request.AddParameter("machine[serial_number]", machinenr);
                request.AddParameter("machine[safe_token]", safe_token);
                request.AddFile("receipt[receipt_file]", File.ReadAllBytes(path), Path.GetFileName(path), "application/octet-stream");
    
                // Add HTTP Headers
                request.AddHeader("Content-type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.RequestFormat = DataFormat.Json;
                //set request Body
                //request.AddBody(req); 
    
    
                // execute the request
                //calling server with restClient
                RestClient restClient = new RestClient("http://localhost:3000");
                restClient.ExecuteAsync(request, (response) =>
                {
    
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //upload successfull
                        MessageBox.Show("Upload completed succesfully...\n" + response.Content);
                    }
                    else
                    {
                        //error ocured during upload
                        MessageBox.Show(response.StatusCode + "\n" + response.StatusDescription);
                    }
                });
       
            }
    
        }
    
    }
