            var bob = new {
                name = "test"
                ,orders = new[] {
                    new  { itemNo = 1, description = "desc"}
                    ,new  { itemNo = 2, description = "desc2"}
                }
            };
            return Json(bob, JsonRequestBehavior.AllowGet);
