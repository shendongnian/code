            MemoryStream ms = new MemoryStream(buffer);
            string chaine = Encoding.UTF8.GetString(buffer);
            string[] pos = chaine.Split('/');
                pX = Convert.ToInt32(pos[0]);
                pY = Convert.ToInt32(pos[1]);
                //posX.Text = pX.ToString();
                //posY.Text = pY.ToString();
            ms.Close();
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X + pX, Cursor.Position.Y + pY);
            posX.Text = Cursor.Position.X.ToString();//try to get X in textbox
            posY.Text = Cursor.Position.Y.ToString();//try to get Y in textbox
        }
        catch (Exception) { }
