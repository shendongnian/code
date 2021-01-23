    using (StreamWriter sw = System.IO.File.CreateText(@"\Storage Card\temp\filename01.xml"))
    {
        if ( sw.BaseStream.Length > 0)
        {
           xmldocData.Save(sw);
        }
        sw.Flush();
        sw.Close();
    }
