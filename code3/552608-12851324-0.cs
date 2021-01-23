        double mouseVerticalPosition;
        double mouseHorizontalPosition;        
        DateTime clickedTime;
        bool IsSecondClick = false;
        void button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
           {
               if(IsSecondClick)
               {
                               
                 IsSecondClick = false;
                 if ((y - mouseVerticalPosition == 0) & y - mouseHorizontalPosition == 0) &
                 clickedTime - DateTime.Now < SOMETIME )
                 { 
                   // mouse double click happenes
                 }
               }
               else
               {
                 IsSecondClick = true;
                 clickedTime = DateTime.Now;
                 mouseVerticalPosition = e.GetPosition(null).Y;
                 mouseHorizontalPosition = e.GetPosition(null).X;               
               }
           }
        
