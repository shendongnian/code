    public static List<Parada> parsear(string html)
    {
        int cual = 0;
        int _parada = 0;
        string _destino = "";
        List<Parada> lp = new List<Parada>();
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        foreach (HtmlNode tabla in doc.DocumentNode.SelectNodes("//table//tr//td"))
        {
            cual = 1 - cual;
            if (cual == 1)
            {
                _parada = Int32.Parse(tabla.InnerText);
            }
            else
            {
                _destino = tabla.InnerText;
                lp.Add(new Parada(_parada , _destino));
            }
        }
        return lp;
    }
