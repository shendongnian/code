            GraphicsState graphicsState = graphics.Save();
            graphics.TranslateTransform(this.Anchor.Position.X, this.Anchor.Position.Y);
            graphics.RotateTransform(this.Anchor.Rotation);
            graphics.FillRectangle(new SolidBrush(this.Anchor.Color), this.Anchor.GetRelativeBoundingRectangle());
            graphics.Restore(graphicsState);
