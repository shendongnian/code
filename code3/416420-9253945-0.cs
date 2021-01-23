     int a;
     try
     {
     if(sResponseData==null || sResponseData=="" )
      {
      MessageBox.Show("ResponseData is NULL or Empty"); //Shows Error 
      }
      else
      {
        //SresponseData has value
        string sMesg = "LogOn Ext:" + txtdevice.Text;
        SendMessage(sMesg);
         a= Convert.ToInt32(sResponseData).Length;
        //Geting the Script out of the message.
        if (a > 10)
        {
            string stemp = sResponseData;
            string[] sSplit = stemp.Split(new Char[] { ';'});
            foreach (string s in sSplit)
            {
                if ((s.Trim() != "Tag") & (s.Trim() != "StopStart"))
                    sScript = s;
            }
        }
      }
     }
     catch (Execption ex)
     {
     MessageBox.Show(ex.Message); //Shows Error 
     }
 
