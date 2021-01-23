    private void UpdateCaptcha()
    {
    	ImgCaptcha.Image = _broker.GetCaptcha();
    	TbxCaptcha.Text = string.Empty;
    }
