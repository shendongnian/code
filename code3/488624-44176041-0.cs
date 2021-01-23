            try
            {
                // bpac.Document PrnLabel = new bpac.Document ();
                ///  bpac.Document PrnLabel = new bpac.Document();
                bpac.Document doc = new Document();
                // Actualizo los Campos de la Etiqueta.
                // if (PrnLabel.Open(this.txtETQ_Plantilla.Text))
                if (doc.Open (this.txtETQ_Plantilla.Text) != false)
                { // hemos cargado la plantilla corectamente.
                    // Editamos los campos necesarios..
                    // PrnLabel.GetObject("BarCode").Text = Lote + NumSerie;
                    doc.GetObject("BarCode").Text = Lote + NumSerie;
                    // PrnLabel.GetObject ("objName").Text = ETQ_txtNumSerie.Text;
                    // PrnLabel.StartPrint("", PrintOptionConstants.bpoDefault);
                    doc.StartPrint("", PrintOptionConstants.bpoDefault);
                    // PrnLabel.PrintOut(1, PrintOptionConstants.bpoDefault);
                    doc.PrintOut(1, PrintOptionConstants.bpoDefault);
                    // PrnLabel.EndPrint();
                    doc.EndPrint();
                    // PrnLabel.Close();
                    doc.Close();
                }
                else
                {
                    MessageBox.Show(this, "Open() Error: " + doc.ErrorCode); //  PrnLabel.ErrorCode);
                }
            }
            catch
            {
                MessageBox.Show(this, "Error de Etiqueta", "Error Etiqueta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
