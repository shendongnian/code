     public decimal Price
        {
            get { return Price; }
            set
            {
                Price=_shiperResposite.GetPriceFromID(Convert.ToInt32(Request.QueryString["ID"]));
                Price = value;
            }
        }
