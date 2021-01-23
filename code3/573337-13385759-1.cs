    public static List<Parada> parsear(string html)
    {
        int cual;
        int _parada;
        string _destino;
        List<Parada> lp = new List<Parada>();
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        cual = 1; _parada = 0; _destino = "";
        foreach (HtmlNode tabla in doc.DocumentNode.SelectNodes("//table//tr//td"))
        {
            if (cual == 1)
            {
                _parada = Int32.Parse(tabla.InnerText);
                cual = 2;
            }
            else if (cual == 2)
            {
                _destino = celda.InnerText;
                cual = 1;
                lp.Add(new Parada(_tabla, _destino));
            }
        }
        return lp;
    }
