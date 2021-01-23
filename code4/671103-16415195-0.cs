        private string BuildDeviceInfo()
        {
            StringBuilder returnValue;
            System.Xml.XmlWriter writer;
            returnValue = new StringBuilder(1024);
            writer = System.Xml.XmlWriter.Create(returnValue);
            writer.WriteStartElement("DeviceInfo");
            writer.WriteElementString("OutputFormat", "EMF");
            if (defaultPageSettings != null)
            {
                // DPI will keep the output from scaling in weird ways
                writer.WriteElementString("PrintDpiX", defaultPageSettings.PrinterResolution.X.ToString());
                writer.WriteElementString("PrintDpiY", defaultPageSettings.PrinterResolution.Y.ToString());
                writer.WriteElementString("PageWidth", (defaultPageSettings.PaperSize.Width / 100m).ToString("F2") + "in");
                writer.WriteElementString("PageHeight", (defaultPageSettings.PaperSize.Height / 100m).ToString("F2") + "in");
           }
            writer.Close();
            return returnValue.ToString();
        }
