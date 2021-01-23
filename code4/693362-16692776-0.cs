    namespace EPSInvoice_ServiceLibrary
    {
    
        public class EPS_Service : IEPS_Service
        {
            List<input_params> Users = new List<input_params>();
            List<token_data> token_data = new List<token_data>();
            public decimal cal;
    
            
            public EPS30Ora.LogonResult Invoice(input_params inputparams)
            {
                EPS30Ora.EPS30Svr svr = new EPS30Ora.EPS30Svr();
                EPS30Ora.LogonResult Log_Res = new EPS30Ora.LogonResult();
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.AutoFlush = true;
                Trace.Indent();
    
                if (Users.Exists(Username => Username.Username.Equals(inputparams.Username)))
                {
                    List<input_params> selected = Users.Where(Username => Username.Username.Equals(inputparams.Username)).ToList();
                    Trace.WriteLine("Username: " + inputparams.Username + " ya está logeado " + selected[0].ck);
                    //    svr.PrepareByMoney(selected[0].ck, 1, inputparams.meter_number, 10, 0, ref cal);
                }
                else
                {
    
                    try
                    {
                        Log_Res = svr.LogOnEx("EDEESTE", inputparams.VSID, inputparams.Username, inputparams.Password, "EPS30Ora", ref inputparams.ck);
                        if (Log_Res == EPS30Ora.LogonResult.psOK)
                        {
                            Users.Add(inputparams);
                            Trace.WriteLine("Login OK. Username: " + inputparams.Username);
                            svr.PrepareByMoney(inputparams.ck, 1, inputparams.meter_number, 10, 0, ref cal);
                            object tr_bl = svr.GetInvoiceData(inputparams.ck, svr.Confirm(inputparams.ck));
                            token_data.Add(new token_data() { transfer_number = (string)((object[])(((object[])(((object[])(((object[])(tr_bl))[4]))[1]))[0]))[0] });
                            Trace.WriteLine("Transacción Finalizada. NTC obtenido: " + inputparams.ck);
                            Trace.Unindent();
                        }
                    }
    
                    catch (System.Runtime.InteropServices.COMException ex)
                    {
                        Trace.WriteLine("Se ha producido una excepción: " + ex);
                    }
                }
             return Log_Res;
            }
    
    
    
            
        }
    
    
    
    }
