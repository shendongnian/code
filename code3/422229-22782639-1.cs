        public JsonResult Card2Data()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            OrgChartWithApiContext db = new OrgChartWithApiContext();
            var items = db.Cards.ToList();
            List<Card> topItems = items.Where(item => !item.ParentId.HasValue).ToList();
            topItems.ForEach(item => item.Children = items.Where(child => child.ParentId == item.id).ToList());
            watch.Stop();
            var timetaken = watch.ElapsedMilliseconds;
            return new JsonResult() { Data = topItems, ContentType = "Json", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
