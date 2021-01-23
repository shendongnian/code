        public static string LoadControlToHtml(Page page, UserControl userControl)
        {
            string html = null;
            try
            {
                HtmlForm form = new HtmlForm();
                form.Controls.Add(userControl);
                page.Controls.Add(form);
                MemoryStream ms = new MemoryStream();
                StreamWriter sw = new StreamWriter(ms);
                HttpContext.Current.Server.Execute(page, sw, false);
                sw.Flush();
                string sa = sw.Encoding.GetString(ms.ToArray());
                sw.Close();
                html = HtmlHelper.RemoveFromTag(sa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return html;
        }
