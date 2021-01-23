    public static XDocument CreatePlaylist(System.Data.DataTable DataTable)
            {
                var xDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                var xItem = new XElement("item");
                foreach (var row in DataTable.Rows.OfType<System.Data.DataRow>())
                    xItem.Add(new XElement("list",
                                new XAttribute("name", row["name"].ToString()),
                                new XAttribute("videotitle", row["videotitle"].ToString()),
                                new XAttribute("link", row["link"].ToString()),
                                new XElement("thumb", row["thumb"].ToString())));
                xDoc.Add(xItem);
                return xDoc;
            }
