    DataTable xmlComments = new DataTable();
    xmlComments.TableName = "item"; //<---- Added
    xmlComments.Columns.Add("User", typeof(string));
    xmlComments.Columns.Add("Date", typeof(string)); //<---- Type changed
    xmlComments.Columns.Add("Comment", typeof(string));
    xmlComments.Columns.Add("Restricted", typeof(string)); //<---- Column name changed
    xmlComments.ReadXml(xmlStream);
