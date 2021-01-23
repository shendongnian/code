        private static XElement root = XElement.Load("Simpman.xml");
        public static string GetPrevOrNext(int itemCount)
        {
            XElement item =
			(from element in root.Elements("myself")
			where (int)element.Element("pid") == itemCount
			select element.Element("name")).SingleOrDefault();
			
            return item != null ? item.Value : "Please check the Index";
        }
