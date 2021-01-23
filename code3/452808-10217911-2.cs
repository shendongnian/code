            System.IO.MemoryStream stream = (System.IO.MemoryStream)doc.ExportToStream(ExportFormatType.PortableDocFormat);//leftover code from previous functionality (i dont think it is doing anything)
    
            BinaryReader Bin = new BinaryReader(doc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType="application/pdf";
            Response.BinaryWrite(Bin.ReadBytes(Convert.ToInt32(Bin.BaseStream.Length)));
            Response.Flush();
