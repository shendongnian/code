      class Program
      {
        private static readonly string url = "http://www.cmegroup.com/clearing/trading-practices/CmeWS/mvc/xsltTransformer.do?xlstDoc=/XSLT/md/blocks-records.xsl&url=/da/BlockTradeQuotes/V1/Block/BlockTrades?exchange={0}&foi={1}&{2}&tradeDate={3}&sortCol={4}&sortBy={5}&_=1372913232800";
    
        static void Main(string[] args)
        {
          Exchange exchange = Exchange.XCME;
          ContractType contractType = ContractType.FUT | ContractType.OPT | ContractType.SPD;
          string assetClass = "assetClassId=0"; // See asset_class dropdown options in HTML source for valid values
          DateTime tradeDate = new DateTime(2013, 7, 3);
          string sortCol = "time"; // Column to sort
          SortOrder sortOrder = SortOrder.desc;
    
          string xml = QueryData(exchange, contractType, assetClass, tradeDate, sortCol, sortOrder);
          Console.WriteLine(xml);
        }
    
        private static string QueryData(Exchange exchange, ContractType contractType, string assetClass, DateTime tradeDate, string sortCol, SortOrder sortOrder)
        {
          string exc = GetEnumString(exchange);
          string ct = GetEnumString(contractType);
          string td = tradeDate.ToString("MMddyyyy");
          string query = string.Format(url, exc, ct, assetClass, td, sortCol, sortOrder.ToString());
    
          WebRequest request = WebRequest.Create(query);
          request.Credentials = CredentialCache.DefaultCredentials;
          using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
          {
            using (Stream stream = response.GetResponseStream())
            {
              using (StreamReader reader = new StreamReader(stream))
              {
                return reader.ReadToEnd();
              }
            }
          }
        }
    
        private static string GetEnumString(Enum item)
        {
          return item.ToString().Replace(" ", "");
        }
      }
    
      [Flags]
      enum Exchange
      {
        /// <summary>
        /// CBOT.
        /// </summary>
        XCBT = 1,
    
        /// <summary>
        /// CME.
        /// </summary>
        XCME = 2,
    
        /// <summary>
        /// COMEX.
        /// </summary>
        XCEC = 4,
    
        /// <summary>
        /// DME.
        /// </summary>
        DUMX = 8,
    
        /// <summary>
        /// NYMEX.
        /// </summary>
        XNYM = 16
      }
    
      [Flags]
      enum ContractType
      {
        /// <summary>
        /// Futures.
        /// </summary>
        FUT = 1,
    
        /// <summary>
        /// Options.
        /// </summary>
        OPT = 2,
    
        /// <summary>
        /// Spreads.
        /// </summary>
        SPD = 4
      }
    
      enum SortOrder
      {
        /// <summary>
        /// Ascending.
        /// </summary>
        asc,
    
        /// <summary>
        /// Descending.
        /// </summary>
        desc
      }
