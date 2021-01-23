          protected void Page_Load(object sender, EventArgs e)
          {
               (SalesSQLEntities db = new SalesSQLEntities())
               {
                    // Get user ID
                    System.Guid UserID = Tools.Tools.getCompanyGuid();
                    // Find all transactions of this company
                    var devItemList = (from dev in db.Devices
                                           where dev.Location.CompanyGuid == UserID
                                           select dev).ToList();
                    DeviceList.DataSource = devItemList;
                    DeviceList.DataBind();
                }
          }
