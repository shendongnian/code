        custom[] customfield = new custom[0]; 
        public Frm()
            InitializeComponent();
        private void c()
        {
            int cu = 0;
            string na = "";
            string fi = "";
            
            int i = 0;
            dGV_output.RowCount = 1;
            dGV_output.ColumnCount = 3;
            dGV_output.RowHeadersVisible = false;
            dGV_output.ColumnHeadersVisible = false;
            dGV_output.Rows.Add("customernumber", "name", "firsname");
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Texts (*.xml)|*.xml|all files (*.*)|*.*",
                Title = ""
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                riTB_ausgabe.Clear();
                XmlTextReader xr = new XmlTextReader(ofd.FileName);
                while (xr.Read()) 
                {
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        if (xr.AttributeCount > 0)
                        {
                            while (xr.MoveToNextAttribute())
                            {
                                
                                switch (xr.Name)
                                {
                                    case "customernumber":
                                        ku = Convert.ToInt32(xr.Value);
                                        break;
                                    case "name":
                                        na = xr.Value;
                                        break;
                                    case "firsname":
                                        vo = xr.Value;
                                        break;
                                }
                                riTB_ausgabe.Text +=
                                    xr.Name + " -> " + xr.Value + "\n";
                            }
                            riTB_ausgabe.Text += "\n";
                            Array.Resize(ref customfield, customfield.Count() + 1); 
                            customfield[i] = new custom(ku, na, vo); 
                            i++;
                            dGV_ausgabe.Rows.Add(cu, na, fi);
                        }
                    }
                }
                xr.Close();
            }
        }
        private void C_add(object sender, EventArgs e)
        {
            if(txt_cnr.Text!="" && txt_name.Text != "" && txt_firstname.Text!="")
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Xml-file(.xml)|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    XmlTextWriter xw = new XmlTextWriter(sfd.FileName, new UnicodeEncoding());
                    custom k = new custom(Convert.ToInt16(txt_cnr.Text), Convert.ToString(txt_name.Text), Convert.ToString(txt_firstname.Text));
                    Array.Resize(ref customfield, customfield.Count() + 1);
                    customfield[customfield.Count() - 1] = k;
                    xw.WriteStartDocument();
                    xw.WriteStartElement("customerlist");
                    foreach (Kunde k1 in customfield)
                    {
                        k1.asXmlElementWrite(xw);
                    }
                    xw.WriteEndElement();
                    xw.Close();
                }
            }
            else { MessageBox.Show("error"); }
        }
    }
