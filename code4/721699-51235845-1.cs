            // update rotation and start batch
            rotation += 0.01f;
            spriteBatch.Begin();
            // dest and origin values (play with these to see different results)
            var dest = new Rectangle(new Point(200, 200), new Point(100, 200));
            var origin = new Vector2(15, 200);
            // draw sprite
            spriteBatch.Draw(rectTexture, dest, null, Color.White, rotation, origin, SpriteEffects.None, 0f);
            // draw sprite bounding box (in my case I put the functions under Source.Graphics.Utils static class)
            var boundingBox = Source.Graphics.Utils.GetRotatedBoundingBox(dest, rotation, origin, rectTexture.Bounds);
            spriteBatch.Draw(rectTexture, boundingBox, Color.Red);
            // end batch
            spriteBatch.End();
