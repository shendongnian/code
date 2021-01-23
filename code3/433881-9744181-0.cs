        private void btnStart_Click(object sender, EventArgs e)
        {
            using (var browser = new IE("http://godev/review"))
            {
                browser.Link(Find.ByText("My Direct Reports")).Click();
                TableRow tr = browser.Span(Find.ByText("JOHN DOE")).Parent.Parent as TableRow;
                SelectList objSL = null;
                if (tr.Exists)
                {
                    foreach (var td in tr.TableCells)
                    {
                        objSL = td.ChildOfType<SelectList>(Find.Any) as SelectList;
                        if (objSL.Exists) break;
                    }
                    if (objSL != null && objSL.Exists)
                    {
                        Option o = objSL.Option(Find.ByText("View Direct Reports"));
                        if (o.Exists) o.Select();
                    }
                }
            }
        }
