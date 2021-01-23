    protected void Page_Load(object sender, EventArgs e)
        {   
            string _GenerateString = @"Number One 1<sup>st</sup> , the very first image creation.";
            StringBuilder sb_GenerateHTMLContent = new StringBuilder();
            sb_GenerateHTMLContent.Append(" <div style=\" white-space: nowrap \"> ");
            sb_GenerateHTMLContent.Append( _GenerateString );
            sb_GenerateHTMLContent.Append(" </div>");
            var bmp = MakeScreenshot(sb_GenerateHTMLContent.ToString());
            bmp.Save(@"C:\test_web.jpg");
        }
        public Bitmap MakeScreenshot(string html)
        {
            // Load the webpage into a WebBrowser control
            WebBrowser wb = new WebBrowser();
            Bitmap bitmap = null;
            try
            {
                wb.Navigate("about:blank");
                if (wb.Document != null)
                {
                    wb.Document.Write(html);
                }
                wb.DocumentText = html;
                wb.ScrollBarsEnabled = false;
                wb.ScriptErrorsSuppressed = true;
                wb.Width = 0;
                while (wb.ReadyState != WebBrowserReadyState.Complete)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
                StringBuilder sb_style_body = new StringBuilder();
                sb_style_body.Append(" margin-top:0; ");
                sb_style_body.Append(" margin-right:0; ");
                sb_style_body.Append(" margin-left:0; ");
                sb_style_body.Append(" margin-bottom:0; ");                
                sb_style_body.Append(" padding-top:0; ");
                sb_style_body.Append(" padding-bottom:0; ");
                sb_style_body.Append(" padding-right:0; ");
                sb_style_body.Append(" padding-left:0; ");
                sb_style_body.Append(" font-family:Arial,Helvetica,sans-serif; ");
                sb_style_body.Append(" font-size:medium; ");
                wb.Document.Body.Style = sb_style_body.ToString();
                wb.Height = wb.Document.Body.ScrollRectangle.Height;
                wb.Width = wb.Document.Body.ScrollRectangle.Width;
                        
                bitmap = new Bitmap(wb.Width, wb.Height);
                wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                wb.Dispose();
            }
            return bitmap;
        }
