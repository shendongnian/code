    private void cadeiaapagarcampos(TextBox _text, EventArgs e)
            {
                if (_text.Text == "")
                {
    				int iAcessorioContar = 10;
    				for (int iContador = 2; iContador <= iAcessorioContar; iContador++) {
    					Label lblAcessorio = (Label)gpbCategoria.Controls.Find("lblAcessorio"+iContador, false).FirstOrDefault();
    					TextBox txtAcessorio = (TextBox)gpbCategoria.Controls.Find("txtAcessorio"+iContador, false).FirstOrDefault();
    				
    					if (txtAcessorio != null && txtAcessorio.TextLength == 0)
    					{
    						gpbCategoria.Controls.Remove(txtAcessorio);
    						gpbCategoria.Controls.Remove(lblAcessorio);
    						btnSalvar.Focus();
    						if (test != 1) {
    							n--;
    							t++;
    							if (n >= 1 && n <= 10)
    							{
    								testeapagar();
    								test = 1;
    							}
    						}                    
    					}
    				}
                }
            }
