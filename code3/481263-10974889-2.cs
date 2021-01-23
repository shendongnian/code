            List<string> headers = new List<string>();
            List<string> footers = new List<string>();
            foreach (Section aSection in app.ActiveDocument.Sections)
            {
                foreach (HeaderFooter aHeader in aSection.Headers)
                    headers.Add(aHeader.Range.Text);
                foreach (HeaderFooter aFooter in aSection.Footers)
                    footers.Add(aFooter.Range.Text);
            } 
