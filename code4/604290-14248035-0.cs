		Graphics grToDrawOn = null;
		Bitmap bmToDrawOn = null;
		private void DgmWin_Paint(object sender, PaintEventArgs _e){
			int w = ClientRectangle.Width;
			int h = ClientRectangle.Height;
			Graphics gr = _e.Graphics;
			// if the bitmap needs to be made, do so
			if (bmToDrawOn == null) bmToDrawOn = new Bitmap(w, h, gr);
			// if the bitmap needs to be changed in size, do so
			if (bmToDrawOn.Width != w || bmToDrawOn.Height != h){
				bmToDrawOn = new Bitmap(w, h, gr);
			}
			// hook the bitmap into the graphics object
			grToDrawOn = Graphics.FromImage(bmToDrawOn);
			// clear the graphics object before drawing
			grToDrawOn.Clear(Color.White);
			// paint everything
			DoPainting();
			// copy the bitmap onto the real screen
			_e.Graphics.DrawImage(bmToDrawOn, new Point(0,0));
		}
		private void DoPainting(){
			grToDrawOn.blahblah....
		}
