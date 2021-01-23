          DataTable dtOutput= new DataTable();
          [WebMethod]
          public void TestService(DataTable dtInput , ref DataTable dtOutput)
          {
            DataRow drRow;
            drRow= dtInput.NewRow();
            drRow["ID"] = 2;
            drRow["Name"] = "Success";
            dtInput.Rows.Add(drRow);
            dtOutput= dtInput;
           }
