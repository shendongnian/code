    public ActionResult PaypalConfirmation(string token, string payerID)
    {
        var message = "Trying to confirm paypal.";
        SendEmail(message, message);
    
        try
        {
            message = "Getting current cart.";
            SendEmail(message, message);
    
            Cart cart = GetCurrentCart();
    
            message = cart == null
                ? "Current cart is null."
                : "Current cart is not null.";
            SendEmail(message, message);
    
            if (cart == null)
            {
                if (token != null && token != "")
                {
                    message = "Getting temp cart by alternate order number.";
                    SendEmail(message, message);
    
                    var tempCart = Cart.GetByAlternateOrderNumber(token);
    
                    message = "Getting temp cart by alternate order number.";
                    SendEmail(message, message);
    
                    if (tempCart != null)
                    {
                        message = "Temp cart is not null";
                        SendEmail(message, message);
    
                        cart = tempCart;
                    }
                    else
                    {
                        message = "Temp cart was null.";
                        SendEmail(message, message);
    
                        ViewBag.PaypalError = "we were unable to retreive your cart.";
    
                        message = "ViewBag.PayPalError set, returning view.";
                        SendEmail(message, message);
    
                        return View("~/Views/Error/PayPal.cshtml");
                    }
                }
                else
                {
                    message = "Setting ViewBag.PayPalError message.";
                    SendEmail(message, message);
    
                    // Line which errors
                    ViewBag.PaypalError = "we were unable to retreive your cart.";
    
                    message = "ViewBag.PayPalError set, returning view.";
                    SendEmail(message, message);
    
                    return View("~/Views/Error/PayPal.cshtml");
                }
            }
    
            // More execution code here, including the "Everything worked" return.
            message = "Executing more code.";
            SendEmail(message, message);
        }
        catch (Exception ex)
        {
            SendEmail(ex.GetType().Name + " caught", ex.Source);
            return View("~/Views/Error/PayPal.cshtml");
        }
    }
