            private List<PhrasalVerb> ExtractVerbsFromMainPage(string content)
        {
            var verbs =new List<PhrasalVerb>(); ;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);
            var rows = doc.DocumentNode.SelectNodes("//table[@class='idioms-table']//tr");
            rows.RemoveAt(0); //remove header
            foreach (var row in rows)
            {
                var cols = row.SelectNodes("td");
                verbs.Add(new PhrasalVerb { 
                Uid = Guid.NewGuid(),
                Name = cols[0].InnerHtml,
                Definition = cols[1].InnerText,
                Count =int.TryParse(cols[2].InnerText,out _) == true ? Convert.ToInt32(cols[2].InnerText) : 0
                });
            }
            return verbs;
        }
