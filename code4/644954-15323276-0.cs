            string[] filePaths = Directory.GetFiles("C:/Users/Movements/Form/","*.jpg");
            string[] User_Moves_filePaths = Directory.GetFiles("C:/Users/Movements/User/", "*.jpg");
            System.Drawing.Image[] Form_Move = new System.Drawing.Image[9];
            System.Drawing.Image[] User_Move = new System.Drawing.Image[9]; 
            int i = 0;
            int j = 0;
                        
            foreach (string name in filePaths)
            {
                Console.WriteLine(name);//Kept in for testing purposes SolidBrush Image CancelEventArgs see that array is being populated in correct order
                Form_Move[i] = System.Drawing.Image.FromFile(filePaths[i]);
                i++;
            }
            
            foreach (string User_Move_name in User_Moves_filePaths)
            {
                Console.WriteLine(User_Move_name);
                User_Move[j] = System.Drawing.Image.FromFile(User_Moves_filePaths[j]);
                j++;
            }
