            // Set the text property of the total literal below the GridView
            OrderTotal.Text = string.Format((HttpUtility.HtmlDecode(
                (string)GetGlobalResourceObject("ShopStrings", "UsdPrice"))),
                                                            _totalExtendedPrice);
        }
