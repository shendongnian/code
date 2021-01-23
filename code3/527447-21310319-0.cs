              private void button2_Click(object sender, EventArgs e)
                {
                    Dictionary<string, string> Data_Array = new Dictionary<string, string>();
                    Data_Array.Add("XML_File", "Settings.xml");
        
                    XML_Array(Data_Array);
                }
              static void XML_Array(Dictionary<string, string> Data_Array)
                {
                    String xmlfile = Data_Array["XML_File"];
                }
