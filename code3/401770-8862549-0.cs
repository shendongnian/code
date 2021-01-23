    string tickerid = "Bse_Prc_tick";
    HtmlAgilityPack.HtmlDocument doc = new HtmlWeb().Load(@"http://www.moneycontrol.com/india/stockpricequote/computers-software/infosys-technologies/IT", "GET");
    if(doc != null)
    {
       // Fetch the stock price from the Web page
       string stockprice = doc.DocumentNode.SelectSingleNode(string.Format(".//*[@id='{0}']",tickerid)).InnerText;
       Console.WriteLine(stockprice);
    }
