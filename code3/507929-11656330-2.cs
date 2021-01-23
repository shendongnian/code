    ...
    case "Print_Contract":
         strContractFilePath = ConfigurationManager.AppSettings["CustomerContractsDirectory"].ToString();
         row1 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
         intId = Convert.ToInt32(grdWebs.DataKeys[row1.RowIndex].Value.ToString());
         objWeb = QDServiceHelper._QDClient.GetDetails(intId);
         lstOnlineCustomerDocuments = QDServiceHelper._QDClient.GetOnlineCustomerDocumentsByID(intId);
         contract = lstOnlineCustomerDocuments.ElementAt(0);
         strContractpath = contract.DocumentFileName;                    
         
         //System.Diagnostics.Process.Start(strContractpath);
         
         StreamReader sr = new StreamReader(strContractpath);
         while(sr.Peek() >= 0)
         {
              line=sr.ReadLine();
              Response.Write(line);
         }
         
         break;               
    ...
