    if (File.Exists(appPath + "\\rptBookDetails.Template"))
        {
            FinalOutPut = File.ReadAllText(appPath + "\\rptBookDetails.Template");
            FinalOutPut = FinalOutPut.Replace("{AccessionNo}", dsBookDetails.Tables[0].Rows[0]["AccessionNo"].ToString());
            FinalOutPut = FinalOutPut.Replace("{Title}", dsBookDetails.Tables[0].Rows[0]["TITLE"].ToString());
            FinalOutPut = FinalOutPut.Replace("{Edition}", dsBookDetails.Tables[0].Rows[0]["EDITION"].ToString());
            FinalOutPut = FinalOutPut.Replace("{Volume}", dsBookDetails.Tables[0].Rows[0]["Volume"].ToString());
            FinalOutPut = FinalOutPut.Replace("{Authors}", dsBookDetails.Tables[0].Rows[0]["Authors"].ToString());
            FinalOutPut = FinalOutPut.Replace("{Pages}", dsBookDetails.Tables[0].Rows[0]["PAGES"].ToString());
            FinalOutPut = FinalOutPut.Replace("{Publication}", dsBookDetails.Tables[0].Rows[0]["PUB_PLACE"].ToString());
            FinalOutPut = FinalOutPut.Replace("{PublicationYear}", dsBookDetails.Tables[0].Rows[0]["YEAR_O_PUB"].ToString());
            FinalOutPut = FinalOutPut.Replace("{Price}", dsBookDetails.Tables[0].Rows[0]["COST"].ToString());
            FinalOutPut = FinalOutPut.Replace("{Supplier}", dsBookDetails.Tables[0].Rows[0]["AccessionNo"].ToString());
            FinalOutPut = FinalOutPut.Replace("{BillNo}", dsBookDetails.Tables[0].Rows[0]["BILL_NO"].ToString());
            FinalOutPut = FinalOutPut.Replace("{BillDate}", dsBookDetails.Tables[0].Rows[0]["DT_O_BILL"].ToString());
            FinalOutPut = FinalOutPut.Replace("{Grant Source}", dsBookDetails.Tables[0].Rows[0]["GRANT_SR"].ToString());
            
            tblHistry.Visible = True;
        } else {
            tblHistry.Visible = False;
        }
