        [HttpPost]
        public void AddSell(string sellList)
        {
            var sellList = JsonConvert.DeserializeObject<List<Sell>>(sellListJson);
            BD.SaveSellList(sellList);
        }
