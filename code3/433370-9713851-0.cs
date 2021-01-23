            var open = new System.Windows.Forms.OpenFileDialog { Multiselect = false };
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(open.FileName);
                try
                {
                    imgBack.Source = new BitmapImage(new Uri(fi.FullName));
                }
                catch (Exception)
                {
                    imgBack.Source = new BitmapImage(new Uri(App.DefaultBackImgPath));
                }
                
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = imgBack.Source;
                System.Windows.Application.Current.Resources["BackBrush"] = brush;
             }
