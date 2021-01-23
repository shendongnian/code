        string connectionString = ConfigurationManager.ConnectionStrings["KTConnectionString"].ToString();
        cmd.Connection = con;
        KTDataContext dataContext = new KTDataContext(connectionString);
        DWH_SmartList tbip = new DWH_SmartList();
        tbip.Sql_Query = txtQuery.Text;
        tbip.Y_Axis = Dd_ListY.SelectedValue;
        tbip.Y1_Axis = Dd_ListYSec.SelectedValue;
        tbip.Y2_Axis = Dd_List3.SelectedValue;
        tbip.Y3_Axis = Dd_List4.SelectedValue;
        tbip.Y4_Axis = Dd_List5.SelectedValue;
        tbip.SmartList_Description = txt_SmartList.Text;
        tbip.User_Code = Convert.ToInt32(  Session["UserCode"]); 
        dataContext.DWH_SmartLists.InsertOnSubmit(tbip);
        dataContext.SubmitChanges();
    }
