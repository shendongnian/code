     void verificationControl_OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            clearInfoBoxTimer.Stop();
    
            DateTime entryTime = DateTime.Now;
    
            DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
            DPFP.Verification.Verification.Result res = new DPFP.Verification.Verification.Result();
    
            employee employees = null;
            foreach (fingerprint fingerPrint in this.db.fingerprints)
            {
                DPFP.Template template = new DPFP.Template();
                template.DeSerialize(fingerPrint.data);
                ver.Verify(FeatureSet, template, ref res); 
                if (res.Verified)
                {
                    db.Connection.Close(); //I close the connection first
                    db.Connection.Open(); // then I open it again
                    employees = fingerPrint.employee; 
                    break;
                }
            }
         }
