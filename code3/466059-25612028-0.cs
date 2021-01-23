     async Task<string> HttpGetAsync(string URI)
        {
            try
            {
                HttpClient hc = new HttpClient();
                Task<Stream> result = hc.GetStreamAsync(URI);
                Stream vs = await result;
                StreamReader am = new StreamReader(vs);
                return await am.ReadToEndAsync();
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.NameResolutionFailure:
                        MessageBox.Show("domain_not_found", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                        //Catch other exceptions here
                }
            }
        }
