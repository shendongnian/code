			XElement data = new XElement("data");
			XDocument document = new XDocument(data);
			int counter = 0;
			foreach (string entry in File.ReadAllLines(csvPath))
			{
				string[] fields = entry.Split(new char[] { ';' },
                                    StringSplitOptions.RemoveEmptyEntries);
				XElement category = new XElement("category",
					new XAttribute("idCategory", fields[0]),
					new XAttribute("CategoryName", fields[1]));
				data.Add(category);
				XElement products = new XElement("products");
				category.Add(products);
				for (int i = 2; i < fields.Length; ++i)
				{
					products.Add(new XElement("product",
						new XAttribute("IdProduct", counter++),
						new XAttribute("Rif", fields[0]),
						new XAttribute("ProductName", fields[i])));
				}
			}
			document.Save(xmlPath);
 
}
