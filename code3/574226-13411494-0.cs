        public override void TouchesBegan (NSSet touches, UIEvent evt)
        {
            base.TouchesBegan (touches, evt);
            
            UITouch touch = touches.AnyObject as UITouch;
            
            if (touch != null && touch.View != this) {
                var rp = touch.LocationInView (touch.View);
                var p = new PointF(touch.View.Frame.X + rp.X, touch.View.Frame.Y + rp.Y);
                // Do your stuff
            }
        }
