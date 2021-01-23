        public static string ControlRenderToString(Control tmpControl)
        {
            string Content;
            System.IO.StringWriter sWriter = new System.IO.StringWriter();
            HtmlTextWriter htwObject = new HtmlTextWriter(sWriter);
            tmpControl.RenderControl(htwObject);
            Content = sWriter.ToString();
            sWriter.Close();
            return Content;
        }
