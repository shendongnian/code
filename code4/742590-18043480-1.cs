        public MyApplicationContext()
        {
           bool isSuccessful = false;
           do
           {
                try
                {
                    lgFrm = new Login_Form();
                    lgFrm.ShowDialog();
                    if (lgFrm.LogonSuccessful)
                    {
                        isSuccessful = lgFrm.LogonSuccessful;
                        ////lgFrm.Close();
                        lgFrm.Dispose();
                        FormCollection frm = Application.OpenForms;
                        try
                        {
                            foreach (Form fc in frm)
                                fc.Close();
                        }
                        catch (Exception ex){}
                        Application.Run(new Main_Form());
                    }
                }
                catch (Exception ex){}
            }while(isSuccessful);
        }
