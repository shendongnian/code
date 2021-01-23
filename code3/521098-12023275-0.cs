    private void Print_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
        if (printDialog.ShowDialog() == true)
        {                
            DrawingVisual dv = new DrawingVisual();
            var dc = dv.RenderOpen();
             SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Database\Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                SqlCommand cmd = new SqlCommand();
                
                BitmapImage bmp = new BitmapImage();
                cmd.CommandText = "Select Picture from Database where Code=@Code";
                cmd.Parameters.Add("@Code", SqlDbType.NVarChar, 30);
                cmd.Parameters["@Code"].Value = this.txtCode.Text;
                cmd.Connection = con;
                con.Open();
				
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.BeginInit();
                bmp.StreamSource = new System.IO.MemoryStream((Byte[])cmd.ExecuteScalar());
                bmp.EndInit();
                dc.DrawImage(bmp, new Rect(140, 170, 150, 150));
            dc.DrawText(new FormattedText("Name:", CultureInfo.GetCultureInfo("en-us"), FlowDirection,
                 new Typeface(new System.Windows.Media.FontFamily("Courier New"), FontStyles.Normal, FontWeights.Bold,
                     FontStretches.Normal), 12, System.Windows.Media.Brushes.Black), new System.Windows.Point(700, 180));
            dc.DrawText(new FormattedText(txtName.Text, CultureInfo.GetCultureInfo("en-us"), FlowDirection,
                  new Typeface(new System.Windows.Media.FontFamily("Courier New"), FontStyles.Normal, FontWeights.Normal,
                      FontStretches.Normal), 11, System.Windows.Media.Brushes.Black), new System.Windows.Point(550, 180));
            dc.Close();
            printDialog.PrintVisual(dv, "Print");
        }
