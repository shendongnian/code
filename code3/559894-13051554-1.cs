         public ActionResult GetOwnerPrice(string ID)
        {
            var currentDealer =  db.Dealers.Single(o => o.UserName == User.Identity.Name);
            var owner = db.Dealers.Single(s => s.DealerID ==currentDealer.OwnerDealerID);
            var card = db.Cards.Single(s => s.SerialNumber == ID);
            var ownerPrice = owner.ProductToSale.Single(pr => pr.ProductID == card.ProductID).SalePrice;
            return Json(ownerPrice, JsonRequestBehavior.AllowGet);
        }
