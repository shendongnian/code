		public void Update() {
            Vector Force = new Vector(0, 0);
			foreach (GravObject g in Form.Objects) {
				if (this != g)
					Force += GetGravEffect(g);
			}
            double TimeElapsedSinceLastUpdate = Form.Timer.Interval * 0.001;
            Vector acceleration = Force / Mass;
            Velocity += acceleration*TimeElapsedSinceLastUpdate;
            X = (X + Velocity.X * Form.VelocityScale);
            Y = (Y + Velocity.Y * Form.VelocityScale);
            if (X + Mass * Form.DrawScale >= Form.Panels.Panel2.Width || X - Mass * Form.DrawScale <= 0)
                Velocity.X *= -1;
            if (Y + Mass * Form.DrawScale >= Form.Panels.Panel2.Height || Y - Mass * Form.DrawScale <= 0)
                Velocity.Y *= -1;
        }
