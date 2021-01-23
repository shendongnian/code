                private void dispatcherTimer_Tick(object sender, EventArgs e)
                {
                    //Random Number Generator
                    Random rnd = new Random();
                    int num = rnd.Next(1, 9);
        
                    //If Random Number is "1" Then Image will display
                    if (num == 1)
                    {
                        ImageSource MoleImage = new BitmapImage(new Uri(ImgNameMole));
                        ImageArray[1].Source = MoleImage;            
                    }
                    //If Random Number does not equal 1
                    if (num != 1)
                    {
                        ImageSource hole = new BitmapImage(new Uri(ImgHole));
                        ImageArray[1].Source = hole;
                    }
        
                    //If Random Number is "2" Then Image will display
                    if (num == 2)
                    {
                        ImageSource MoleImage = new BitmapImage(new Uri(ImgNameMole));
                        ImageArray[2].Source = MoleImage;
                    }
        }
