        private void btnSave_Click(object sender, EventArgs e)
        {
            path = rtxtName.Text;//name of a xml file is name of WPF 'name' field 
            
            doc = new XmlDocument(); //Here i am creating the xmldocument object
           
            string tempPath = path;
            int counter = 0;
        
            while(System.IO.File.Exists(tempPath))
            {
                counter++;
                tempPath = path + counter + ".xml";
            }
            
            doc.CreateTextNode(path);
            CreateNewXMLDoc();
        }
