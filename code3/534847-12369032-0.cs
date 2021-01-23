    //Your xml
    string TestSTring = @"<Contacts> 
                        <Node>
                            <ID>123</ID>
                            <Name>ABC</Name>
                        </Node>
                        <Node>
                            <ID>124</ID>
                            <Name>DEF</Name>
                        </Node>
                </Contacts>";
    StringReader StringStream = new StringReader(TestSTring);
    DataSet ds = new DataSet();
    ds.ReadXml(StringStream);
    DataTable dt = ds.Tables[0];
