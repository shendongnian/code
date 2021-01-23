    private void BtnExecute_OnClick(object sender, EventArgs e)
    {
    		var pessoaJuridica = _broker.Consulta(TbxCNPJ.Text, TbxCaptcha.Text, true);
    		// here you can see props like pessoaJuridica.CNPJ
    }
