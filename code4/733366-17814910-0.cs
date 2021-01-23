    using System;
    using System.Drawing;
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;
    using MonoTouch.Dialog.Utilities;
    
    namespace Zurfers.Mobile.iOS
    {
    	public class CustomCell : UITableViewCell, IImageUpdated
    	{
    		UILabel headingLabel, subheadingLabel, priceLabel;
    		UIImageView imageService;
    		UIImageView star, star2, star3, star4, star5;
    		public CustomCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
    		{
    			imageService = new UIImageView();
    			star   = new UIImageView();
    			star2  = new UIImageView();
    			star3  = new UIImageView();
    			star4  = new UIImageView();
    			star5  = new UIImageView();
    			headingLabel = new UILabel(){
    				Font = UIFont.FromName("Verdana-Bold", 14f),
    				BackgroundColor = UIColor.Clear,
    				TextColor = UIColor.FromRGB(241, 241, 211)
    			};
    			subheadingLabel = new UILabel(){
    				Font = UIFont.FromName("Verdana-Bold", 8f),
    				TextColor = UIColor.FromRGB(255, 255, 255),
    				BackgroundColor = UIColor.Clear
    			};
    			priceLabel = new UILabel(){
    				Font = UIFont.FromName("Verdana", 14f),
    				TextColor = UIColor.FromRGB(241, 241, 211),
    				BackgroundColor = UIColor.Clear
    			};
    
    			AddSubview(imageService);
    			AddSubview(headingLabel);
    			AddSubview(subheadingLabel);
    			AddSubview(priceLabel);
    			AddSubview(star);
    			AddSubview(star2);
    			AddSubview(star3);
    			AddSubview(star4);
    			AddSubview(star5);
    
    		}
    
    		public void UpdateCell (string title, string subtitle, string price, string imageUlr, string rating )
    		{
    			if (imageUlr != null) {
    				var u = new Uri(imageUlr);
    				ImageLoader MyLoader= new ImageLoader(50,50);
    				imageService.Image = MyLoader.RequestImage(u,this);
    
    			} else {
    				imageService.Image = UIImage.FromFile("generic_no_image_tiny.jpg");
    			}
    
    
    			headingLabel.Text = title;
    			subheadingLabel.Text = subtitle;
    			if (subtitle.Length > 40) {
    				subheadingLabel.LineBreakMode = UILineBreakMode.WordWrap;
    				subheadingLabel.Lines = 0;
    			}
    
    			switch (rating) {
    				case "T":
    					star.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star2.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					break;
    				case "S":
    					star.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star2.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star3.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					break;
    				case "F":
    					star.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star2.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star3.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star4.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					break;
    				case "L":
    					star.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star2.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star3.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star4.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					star5.Image = UIImage.FromFile("ZurfersMovil-Stars.png");
    					break;
    			}
    
    
    			priceLabel.Text = "USD" + price;
    			priceLabel.Font = UIFont.BoldSystemFontOfSize (16);
    		}
    
    
    		public void UpdatedImage (Uri uri)
    		{
    			imageService.Image = ImageLoader.DefaultRequestImage(uri, this);
    		}
    
    
    		public override void LayoutSubviews ()
    		{
    			base.LayoutSubviews ();
    			imageService.Frame = new RectangleF(10, 10, 50, 33);
    			headingLabel.Frame = new RectangleF(70, 4, 240, 25);
    			subheadingLabel.Frame = new RectangleF(70, 25, 240, 20);
    			priceLabel.Frame = new RectangleF(220, 45, 100, 20);
    			star.Frame = new RectangleF(70, 45, 15, 15);
    			star2.Frame = new RectangleF(85, 45, 15, 15);
    			star3.Frame = new RectangleF(100, 45, 15, 15);
    			star4.Frame = new RectangleF(115, 45, 15, 15);
    			star5.Frame = new RectangleF(130, 45, 15, 15);
    		}
    	}
    }
