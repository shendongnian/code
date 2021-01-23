        public JsonResult CardData()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            OrgChartWithApiContext db = new OrgChartWithApiContext();
           
            var items = db.Cards.ToList();
            Action<Card> SetChildren = null;
            SetChildren = parent => {
                parent.Children = items
                    .Where(childItem => childItem.ParentId == parent.id)
                    .ToList();
                //Recursively call the SetChildren method for each child.
                parent.Children
                    .ForEach(SetChildren);
            };
            //Initialize the hierarchical list to root level items
            List<Card> hierarchicalItems = items
                .Where(rootItem => !rootItem.ParentId.HasValue)
                .ToList();
            //Call the SetChildren method to set the children on each root level item.
            hierarchicalItems.ForEach(SetChildren);
            watch.Stop();
            var timetaken = watch.ElapsedMilliseconds;
            
            return new JsonResult() { Data = hierarchicalItems, ContentType = "Json", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
