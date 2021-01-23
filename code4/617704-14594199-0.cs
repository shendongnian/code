    HtmlControl control = new HtmlControl(this.UIPersonsCCDWindowsIntWindow.UIDetailsCCDDocument);
            control.SearchProperties.Add(HtmlControl.PropertyNames.ClassName, "HtmlHyperlink");
            UITestControlCollection controlcollection = control.FindMatchingControls();
            List<string> names = new List<string>();
            foreach (UITestControl x in controlcollection)
            {
                if (x is HtmlHyperlink)
                {
                    HtmlHyperlink programCaseLink = (HtmlHyperlink)x;
                    if (programCaseLink.Href.StartsWith("http://mywebsite.com/ProgramCase/Details/"))
                    {
                        Mouse.Click(programCaseLink);
                    }
                }
            }
