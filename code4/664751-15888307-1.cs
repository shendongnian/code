        bool escPressed = false;
        
            ....
            //run your loop in a different thread
            Thread thread = new Thread(new ThreadStart(MyLoop));
            thread.Start();
            ....        
        void MyLoop()
        {
            for (int x = 0; x < nombres.Length; x++)
            {
                if(escPressed) break;
                ValidXX.Text = x.ToString(); ValidXY.Text = nombres.Length.ToString();
                origen = nombres[x];
                cambia = nombres[x];
                pedrito = control.ValidarDocumentoXML(cambia);
                if (pedrito == true)
                { }
                else
                  /*  File.Move (origen , destino );*/
                try
                { }
                catch(IOException iox)
                {  MessageBox.Show(iox.Message); }
                { /* corrupto[x] = cambia; */ MessageBox.Show("malo" + cambia); }
            } 
        }
        private void Importar2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { escPressed = true;}   
        }
