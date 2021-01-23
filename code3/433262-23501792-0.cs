        /// <summary>
        /// Evento que permite ubicar la posicion del mouse y muestra el menu contextual.
        /// </summary>
        private void dgw_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                /*Obtener y seleccion celda donde se hizo el click*/
                DataGridView.HitTestInfo _htInfo = dgw.HitTest(e.X, e.Y);
                dgw.CurrentCell = dgw[_htInfo.ColumnIndex, _htInfo.RowIndex];
                //Invocar evento de apertura de Menu Contextual donde se ocultara si la celda es de lectura,
                //O se mostrara  si la celda es de edicion.
                dgw.ContextMenuStrip.Opening += (s, i) =>
                    {
                        if (dgw.CurrentCell.ReadOnly)
                            i.Cancel = true;//Evita que se muestre el Menu Contextual
                        else
                        {
                            i.Cancel = false;//Permite que se muestre el Menu Contextual
                            ContextMenu.Show(dgw, new Point(e.X, e.Y));                            
                        }                            
                    };                    
            }
        }
