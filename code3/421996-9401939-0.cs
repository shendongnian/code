    using (DdeClient client = new DdeClient("MSACCESS", "MyDB.accdb"))
    {
               String DdeCommand =
                "[OpenForm frmNavigate,,,,,,UserOpenArgs]";
            try
            {
                client.Connect();
                client.Execute(DdeCommand, 5000);
            }
            catch (NDde.DdeException ex)
            {
               // MessageBox.Show(ex.Message);
                Logger.Write(ex.ToString());
            }
     }
