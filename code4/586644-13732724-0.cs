            void button1_onClick(object sender, EventArgs e)
            {
                bool result = IsDivisibleByTwo(1);
            }
    
            void button2_onClick(object sender, EventArgs e)
            {
                bool result = IsDivisibleByTwo(2);
            }
    
            bool IsDivisibleByTwo(int x)
            {
                return (x % 2 == 0);
            }
