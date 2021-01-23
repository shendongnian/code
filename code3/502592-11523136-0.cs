            // don't forget to import TidyNet and System.Xml.Linq
            var t = new Tidy();
            TidyMessageCollection messages = new TidyMessageCollection();
            t.Options.Xhtml = true;
            //extra options if you plan to edit the result by hand
            t.Options.IndentContent = true;
            t.Options.SmartIndent = true;
            t.Options.DropEmptyParas = true;
            t.Options.DropFontTags = true;
            t.Options.BreakBeforeBR = true;
            
            
            
            string sInput = "your html code goes here";
            var bytes = System.Text.Encoding.UTF8.GetBytes(sInput);
            
            StringBuilder sbOutput = new StringBuilder();
            var msIn = new MemoryStream(bytes);
            var msOut = new MemoryStream();
            t.Parse(msIn, msOut, messages);
            var bytesOut = msOut.ToArray();
            string sOut = System.Text.Encoding.UTF8.GetString(bytesOut);
            XDocument doc = XDocument.Parse(sOut);
            //process XML as you like
