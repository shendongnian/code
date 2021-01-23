    private int x = 5;
    
            private void dosomething()
            {
            }
            private void multXby5if5() // Should make x =25, by multiplying 5  if it was 5, finally x should be 25
            {
    
                if (x == 5) // SecondThread reaches here while x is still 5
                {
                    dosomething(); //Main thread reaches here
                    
                    x = x*5; // Then Main Thread comes and makes x =25, then later SecondThread will come make x*5=25*5=125,
    
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Thread tr = new Thread(multXby5if5);
                tr.Name = "SecondThread";
                multXby5if5();
                tr.Start();
            }
