            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ListaFollowUps listaFL = e.Row.DataItem as ListaFollowUps;
                if (listaFL.IDUSUARIORESPONSAVEL == 0)
                {
                    e.Row.Cells[2].Text = "Não Atribuido";
                }
                else
                {
                    e.Row.Cells[2].Text = "listaFl.NmUser";
                }
                if (e.Row.Cells[7].Text == "01/01/0001" || e.Row.Cells[8].Text == "01/01/0001")
                {
                    e.Row.Visible = false; // disable row
                }
            }
        }
