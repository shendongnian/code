            private static void SePageTitle(string pageId, string pageTitle)
        {
            Microsoft.Office.Interop.OneNote.Application m_app = new Microsoft.Office.Interop.OneNote.Application();
            string strPagTitle = "<one:Page xmlns:one=\"http://schemas.microsoft.com/office/onenote/2010/onenote\" ID=\"{0}\" >" +
                  "<one:Title selected=\"partial\" lang=\"en-US\">" +
                    "<one:OE style=\"font-family:Calibri;font-size:17.0pt\">" +
                      "<one:T><![CDATA[{1}]]></one:T> " +
                    "</one:OE>" +
                  "</one:Title>" +
                "</one:Page>";
            strPagTitle = string.Format(strPagTitle, pageId, pageTitle);
            m_app.UpdatePageContent(strPagTitle);
        }
