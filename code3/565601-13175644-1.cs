    protected void repRooms_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ClsRoomNew objRoom = new ClsRoomNew();
        CheckBoxList chkRoomList = (CheckBoxList)e.Item.FindControl("chkRoomList");
        CheckBox Checkbox1 = (CheckBox)e.Item.FindControl("Checkbox1");
        Label lblAreaName = (Label)e.Item.FindControl("lblAreaName");
        if (chkRoomList != null)
        {
            DataTable dt = objRoom.RoomListingByAreaId(Convert.ToInt64(DataBinder.Eval(e.Item.DataItem, "Areaid")));
            if (dt.Rows.Count > 0)
            {
                lblAreaName.Text = DataBinder.Eval(e.Item.DataItem, "Areaname").ToString();
                chkRoomList.DataSource = dt;
                chkRoomList.DataTextField = "RoomName";
                chkRoomList.DataValueField = "RoomId";
                chkRoomList.DataBind();
            }
            else
            {
                Checkbox1.Visible = false;
                chkRoomList.Visible = false;
            }
        }
    }
