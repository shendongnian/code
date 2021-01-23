    [HttpPost]
    public ActionResult HtmlJsonTryout(int amount)
    {
        if (first.CartID == 0)
        {               
            var viewData = m_cartViewDataFactory.Create();
            string miniCart = this.PartialViewToString("_FullCart", viewData);
            string cart = this.PartialViewToString("_CartSum", viewData);
            return Json(new
            {
                Status = "OK",
                MiniCart = miniCart,
                Cart = cart
            });
        }
    }
