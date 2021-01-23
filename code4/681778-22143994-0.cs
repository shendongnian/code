        using System.IO;
        using System.Drawing;
        
        [WebMethod]
            public Byte[] WatermarkImage(Byte[] image)
            {
        MemoryStream ms = new MemoryStream(image);
        Image image2 = Image.FromStream(ms);
        image2.Save(Server.MapPath("~") + "\\imageTest.jpg");
        string strCmdText;
        strCmdText = "/C convert.exe -draw \"gravity south fill black text 0,0 'Parth' \" \"" + Server.MapPath("~") +"\\imageTest.jpg \" \""+Server.MapPath("~") +"\\imageTest_result.jpg \"";
        System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        System.Threading.Thread.Sleep(1000);
        byte[] imgdata = System.IO.File.ReadAllBytes(Server.MapPath("~") +"\\imageTest_result.jpg");
        return imgdata;
            }
