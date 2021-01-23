            if (stateS == "normal")
            {
                if (!MediaPlayer.Equals(playing, normS))
                {
                    playing = normS;
                }
                spriteBatch.Draw(norm, pos, Color.White);
            }
            else if (stateS == "fast")
            {
                if (!MediaPlayer.Equals(playing, fastS))
                {
                    playing = fastS;
                }
                spriteBatch.Draw(fast, pos, Color.White);
            }
            else if (stateS == "slow")
            {
                if (!MediaPlayer.Equals(playing, slowS))
                {
                    playing = slowS;
                }
            }
