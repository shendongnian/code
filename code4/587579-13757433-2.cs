     protected Dictionary<string, string> xmlList;
        protected System.Collections.ArrayList list = new System.Collections.ArrayList();
    
     xmlList = new Dictionary<string, string>();
            xmlList.Add("image", "images/piece1.png");
            xmlList.Add("description", " Experience why entertainment is more amazing with Xbox.");
            xmlList.Add("title", "Downloads");
            list.Add(xmlList);
            xmlList = new Dictionary<string, string>();
            xmlList.Add("image", "images/piece2.png");
            xmlList.Add("description", "Limited-time offer: Buy Office now, get the next version free.*");
            xmlList.Add("title", "Security & Updates");
            list.Add(xmlList);
    
            foreach (Dictionary<string, string> itemList in list)
            {
                Response.Write(itemList["image"]);
                Response.Write("<br>");
            }
