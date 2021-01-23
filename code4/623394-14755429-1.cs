    XElement catalogElements = XElement.Parse(xmldata);
    var result = from item in catalogElements.Elements("product").Elements("catalog_item")
                         select new CatalogItem()
                         {
                             item_num = item.Element("item_number").Value,
                             price = Double.Parse(item.Element("price").Value),
                             sizes = new ObservableCollection<Size>(from sz in item.Elements("size")
                                    select new Size()
                                    {
                                        sizeDesc = sz.Attribute("description").Value,
                                        colorswatches = new ObservableCollection<ColorSwatch>(from cs in sz.Elements("color_swatch")
                                                                                            select new ColorSwatch()
                                                                                            {
                                                                                                 color = cs.Value,
                                                                                                 image = cs.Attribute("image").Value
                                                                                            })
                                    })
                         };
      List<CatalogItem> catalogItems = result.ToList();
      var items = catalogItems.First().sizes.First().sizeDesc; //Medium
      var sjdl  = catalogItems.First().sizes.First().colorswatches.First().color; //Red
