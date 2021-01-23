            // declare these at CLASS level (not in the method that has the code below)
            List<Label> Labels = new List<Label>();
            List<TextBox> TextBoxes = new List<TextBox>();
            ...
                // in some method:
                int iAcessorioContar = 10;
                for (int iContador = 2; iContador <= iAcessorioContar; iContador++)
                {
                    Label lblAcessorio = (Label)gpbCategoria.Controls.Find("lblAcessorio" + iContador, false).FirstOrDefault();
                    TextBox txtAcessorio = (TextBox)gpbCategoria.Controls.Find("txtAcessorio" + iContador, false).FirstOrDefault();
                    Labels.Add(lblAcessorio);
                    TextBoxes.Add(txtAcessorio);
                }
