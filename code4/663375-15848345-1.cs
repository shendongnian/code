        new ReplacePdfLinks
        {
            InputPdf = @"test.pdf",
            OutputPdf = "mod.pdf",
            UriToNamedDestination = uri =>
            {
                if (uri.Host.ToLowerInvariant().Contains("google.com"))
                {
                    return "entry1";
                }
                return string.Empty;
            }
        }.Start();
