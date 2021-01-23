    private void Encrypt()
    {
         byte[] output = new byte[txt_enc_in.Text.Length];
         for (int i = 0; i < output.Length; i++)
         {
              output[i] = my_Des.Encrypt(Convert.ToByte(txt_enc_in.Text[i]));
         }
         txt_enc_out.Text = "";
         for (int i = 0; i < output.Length; i++)
         {
              txt_enc_out.Text += Convert.ToChar(output[i]);
         }
     }  
