    List<string, string> Grids = new List<string, string>(); // <UCId, GridId>
    ...
    ctrIpInterfaceUC = (Test2.SetupGroup.Ipservice.IpInterfaceUC)LoadControl("IpInterfaceUC.ascx");
    string Id = "device_"+ip+"_"+port+"$"+indexInterface;
    GridView ctrGridView = ctrIpInterfaceUC.Grid;
    Grids.Add(Id, ctrGridView.ClientID);
    Control ctr = (Control)ctrIpInterfaceUC;
    ctr.ID = Id
    phDevices.Controls.Add(ctr);//PlaceHolder for add many UserControl
    ...
