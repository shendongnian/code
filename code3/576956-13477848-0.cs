     Fiche_Ordre f_Fiche = null;
    private void Liste_DobleClic(object sender, EventArgs e)
    {
            try
            {
                Program.OrderId = gridView_Liste_Ordres.GetFocusedRowCellValue("NO_ORDRE").ToString();
                Program.StatusOrdre = Convert.ToInt32(gridView_Liste_Ordres.GetFocusedRowCellValue("STATUT_ORDRE"));
                if (gridView_Liste_Ordres.GetFocusedRowCellValue("MODAL_MODE").ToString() == "A")
                f_Fiche = new          Fiche_Ordre(gridView_Liste_Ordres.GetFocusedRowCellValue("NO_ORDRE").ToString());
                f_Fiche.MdiParent = this.MdiParent;
                f_Fiche.Show();
            }
            catch (Exception excThrown)
            {
                MessageBox.Show(excThrown.Message);
            }
    }
