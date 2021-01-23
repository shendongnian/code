        private static XElement root = XElement.Load("Simpman.xml");
        public static string GetItem(int index)
        {
            XElement item =
			(from element in root.Elements("myself")
			where (int)element.Element("pid") == index
			select element.Element("name")).SingleOrDefault();
			
            return item != null ? item.Value : "Please check the Index";
        }
