    public ItemList GetByCity(string limit)
            {           
                DataTable City = ds.Tables["City"];
                    var items = WithHTML(City, limit);
                    return new ItemList { Items = items };
            }
     public List<Item> WithHTML(DataTable City, string limit)
            {
                var items = (from d in City.AsEnumerable()
                             where d.Field<string>("strMainHin") != string.Empty
                             orderby d.Field<DateTime>("dtPosted")
                             select new Item
                             {
                                 ItemId = d.Field<Int32>("intId").ToString(),
                                 ItemLine = htmlEscapes(d.Field<string>("strMainHin")),
                                 Photo = @"http://192.168.1.17:801/ImageById/" + d.Field<Int32>("intId") + ".jpg"
                             }).Take(Convert.ToInt32(limit)).ToList();
    
                return items;
            }
     public string htmlEscape(string input)
            {            var output = String.Join("", WebUtility.HtmlDecode(input).Select(x => "\\u" + ((int)x).ToString("X4")));
                return output;
            }
