    public MyApplicationContext()
        {
                try
                {
                    lgFrm.ShowDialog();
                    if (lgFrm.LogonSuccessful)
                    {
                        ////lgFrm.Close();
                        lgFrm.Dispose();
                        FormCollection frm = Application.OpenForms;
                        try
                        {
                            foreach (Form fc in frm)
                                fc.Close();
                        }
                        catch (Exception ex){}
                        //Application.Run(new Main_Form());  <<<---- Remove this
                        MainForm = new Main_Form();
                    }
                }
                catch (Exception ex){}
            }
