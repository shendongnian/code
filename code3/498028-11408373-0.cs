    private void webCompareSQL_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                if (webCompareSQL.Document != null)
                {
                    webCompareSQL.Document.ContextMenuShowing += DocMouseClick;
                }
            }
            void DocMouseClick(object sender, HtmlElementEventArgs e)
            {
                webCompareSQL.Document.ExecCommand("SelectAll", true, null);
            }
