           HtmlGenericControl div1 = new HtmlGenericControl("div");
           HtmlGenericControl div2 = new HtmlGenericControl("div");
           div1.InnerHtml = "test1";
           div2.InnerHtml = "test2";
           var lst = new List<HtmlGenericControl>
           {
              div1,
              div2
           };
           Random rnd = new Random();
           var shuffled = lst.OrderBy(s => rnd.Next()).ToList();
            int i = 0;
            while (i < lst.ToArray().Length)
            {
                lst[i].InnerHtml = shuffled[i].InnerHtml;
                i++;
            }
            this.Controls.Add(div1);
            this.Controls.Add(div2);
