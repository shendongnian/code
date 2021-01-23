            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                teste listaTeste = e.Row.DataItem as ListaTeste;
                if (listaTeste.ID == 0)
                {
                    e.Row.Cells[2].Text = "Não Atribuido";
                }
                
                if (e.Row.Cells[7].Text == "01/01/0001" || e.Row.Cells[8].Text == "01/01/0001")
                {
                    **e.Row.Visible = false;** // disable row
                }
            }
        }
