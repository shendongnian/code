    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GetList(int branchID, string customer)
    {
        // do your code here
        reqnum[0, 0] = "@RequestingBranchID";
        reqnum[0, 1] = branchID;
        reqnum[1, 0] = "@ProviderBranchID";
        reqnum[1, 1] = customer;
        DataTable dt = SqlCommands.FillData(out OutStatus, out OutMessage, "BSD.SW_Boxes_StockOfProviderAndRequestingBranch", CommandType.StoredProcedure, reqnum);
        if(dt!=null)
        {
              return Newtonsoft.Json.JsonConvert.SerializeObject(dt);
        }
        else{
            //return
        }
    }
