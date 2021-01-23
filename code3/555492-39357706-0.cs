    private void Report_EndRender(object sender, EventArgs e)
        {
            foreach (StiPage page in report.RenderedPages)
            {
                double max = 0;
                foreach (StiComponent comp in page.GetComponents())
                {
                    if (comp.Bottom > max) max = comp.Bottom;
                }
                page.PageHeight = max + page.Margins.Top + page.Margins.Bottom;
                // set height for "Panel1"
                page.Components["Panel1"].Height = page.Height;
            }
        }
