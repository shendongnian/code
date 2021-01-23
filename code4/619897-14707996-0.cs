	public string GetSumary(String ItemEncoded)
	{
        using (var res = new dtSearch.Engine.SearchResults())
        {
            res.UrlDecodeItem(ItemEncoded);
            res.GetNthDoc(0);
            using (var rj = res.NewSearchReportJob())
            {
                // next line asumes you store your document text version in cache. remove if not 
                rj.Flags |= dtSearch.Engine.ReportFlags.dtsReportGetFromCache;
                rj.Flags |= dtSearch.Engine.ReportFlags.dtsReportByWordExact;
                rj.Flags |= dtSearch.Engine.ReportFlags.dtsReportLimitContiguousContext;
                rj.OutputToString = true;
                rj.OutputFormat = dtSearch.Engine.OutputFormats.itUTF8;
                rj.OutputStringMaxSize = 2000;
                rj.MaxContextBlocks = 1;
                rj.WordsOfContext = 12;
                rj.Header = "";
                rj.FileHeader = "";
                rj.ContextHeader = "";
                rj.BeforeHit = "<b>";
                rj.AfterHit = "</b>";
                rj.ContextFooter = "";
                rj.ContextSeparator = " ... ";
                rj.FileFooter = "";
                rj.Footer = "";
                rj.SelectItems(0, 0);
                rj.Execute();
                // some final clean-up
                return
                        new Regex(@"[\t\r\n]+|[\.;\,\*]{2,}").Replace(rj.OutputString, "&nbsp; &nbsp;");            }
        }
	}
