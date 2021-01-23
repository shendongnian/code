      //
      // here you are setting c.SetCaseNo
      //
      c.SetCaseNo = sqlSaveCase.ExecuteNonQuery().ToString();
      string strIPID = cboIPAddress.SelectedValue.ToString();
      //
      // but here you're using c.CaseNo
      //
      SqlCommand sqlNewIPLink = cIPID.NewIPLinkSqlCom(strIPID,c.CaseNo,txtIPRef.Text);
      sqlNewIPLink.Connection = linkToDB;
      sqlNewIPLink.Transaction = transaction;
      sqlNewIPLink.ExecuteNonQuery();   
