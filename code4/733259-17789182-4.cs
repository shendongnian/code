    public class MyItem
    {
        public SynSession Doc;
        public ScreenDef ScreenDef;
        public MyItem(SynSession doc, ScreenDef screenDef)
        {
            Doc = doc;
            ScreenDef = screenDef;
        }
    }
    List<MyItem> tmp = (from oScreenDef in listScreenDefinition
                        let oScreenDefVenueCd = oScreenDef["venueCd"]  // let clause creates a "local variable" Inside a LINQ query
                        join oSynSession in listSynSession on
                            new { c1 = oScreenDefVenueCd, c2 = oScreenDef["screenBytNum"] }
                            equals new { c1 = oSynSession["cinemaId"], c2 = oSynSession["screenDetails"].AsBsonDocument["num"] }
                        join oSessionAreaCount in listSessionAreaCount on
                            oScreenDefVenueCd
                            equals oSessionAreaCount["cinemaId"]
                        join oPrices in listSynPrices on
                            new { c1 = oScreenDefVenueCd, c2 = oSynSession["cinemaId"] }
                            equals new { c1 = oPrices["cinemaId"], c2 = oPrices["cinemaId"] }
                        select new MyItem(oSynSession[0], oScreenDef)).ToList();
