    public abstract class ExportAccountsResult : ActionResult
    {
        protected ExportAccountsResult(IEnumerable<Account> accounts, ExportViewModel exportOptions)
        {
            this.Accounts = accounts;
            this.ExportOptions = exportOptions;
        }
        protected IEnumerable<Account> Accounts { get; private set; }
        protected ExportViewModel ExportOptions { get; private set; }
        protected abstract string ContentType { get; }
        protected abstract string Filename { get; }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = ContentType;
            var cd = new ContentDisposition
            {
                FileName = this.Filename,
                Inline = false
            };
            response.AddHeader("Content-Disposition", cd.ToString());
            // TODO: Use a real CSV parser here such as https://github.com/JoshClose/CsvHelper/wiki/Basics
            // and never roll your own parser as shown in this oversimplified
            // example. Here's why: http://secretgeek.net/csv_trouble.asp
            using (var writer = new StreamWriter(response.OutputStream))
            {
                foreach (var account in this.Accounts)
                {
                    var values = new List<object>();
                    if (this.ExportOptions.IncludeName)
                    {
                        values.Add(account.Name);
                    }
                    if (this.ExportOptions.IncludeDescription)
                    {
                        values.Add(account.Description);
                    }
                    if (this.ExportOptions.IncludeAddress)
                    {
                        values.Add(account.Address);
                    }
                    writer.WriteLine(string.Join(", ", values));
                }
            }
        }
    }
