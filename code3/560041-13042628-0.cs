            GraphicsDevice.Clear(Color.CornflowerBlue);
 
            // TODO: Add your drawing code here
            TextControl textControl = new TextControl();  //Creating the text control
            textControl.Draw();
            base.Draw(gameTime);
        }
