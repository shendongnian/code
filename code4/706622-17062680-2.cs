    class MockDataRetrieval : IDataRetrieval
    {
        public string TestDataXml { get; set; }
        public IEnumerable<IArea> GetAreaList()
        {
            List<IArea> areaList = new List<IArea>();
            
            XmlTextReader areaReader = new XmlTextReader(TestDataXml);
            while (areaReader.Read())
            {
                if (areaReader.NodeType == XmlNodeType.Text)
                    areaList.Add(new Area() { AreaName = areaReader.Value });
            }
            return areaList;
        }
    }
