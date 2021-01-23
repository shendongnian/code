    int iTableNumber = 1;
    // Read input XML
    using (XmlReader xrMeta = XmlReader.Create(new StreamReader(ofdOpenXML.FileName)))
    {
       while (!xrMeta.EOF)
       {
         // Advance to next <record>
         xrMeta.ReadToFollowing("record");
         if (xrMeta.NodeType == XmlNodeType.Element)
         {
            // Advance to the next <fields>
            xrMeta.ReadToFollowing("fields");
            // Read underlying XML - it will be a set of flat tables
            xrSub = xrMeta.ReadSubtree();
            dt = new DataTable();
            ds = new DataSet("fields");
            ds.ReadXml(xrSub);
            dt = ds.Tables[0].Copy();
            dt.TableName = "field_" + iTableNumber.ToString().PadLeft(2, '0');
            MetaXML.Tables.Add(dt);
            iTableNumber++;
          }
       }
     }
     // Populate comboBox to switch between tables in DataSet
     for (int i = 0; i < MetaXML.Tables.Count; i++)
     {
        cbShowTable.Items.Add(MetaXML.Tables[i].TableName);
     }
     // Populate DataGridView with first read table
     dataGridViewMetaXML.DataSource = MetaXML.Tables[0];
