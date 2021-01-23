        public void CheckXWinner(Button[] buttonArray)
        {          
            int arrLength = buttonArray.Length; 
            int root = (int)Math.Sqrt(Convert.ToDouble(arrLength));  
            for (int i = 0;  i < root;  i++)
            {
                //Sets the counter for the winners back to zero
                int d2Count = 0;
                int d1Count = 0;
                int hCount = 0;
                int vCount = 0;
                    for(int j = 0;  j < root; j++)
                    {
                        //increments the appropriate counter if the button contains an X
                        //Horizonal win
                        if (buttonArray[(i*root) + j].Text == "X")
                        {
                            hCount++;
                            if (hCount == root)
                            {
                                for (int z = (root - 1); z >= 0; z--)
                                {
                                    buttonArray[(i*root) + z].BackColor = Color.IndianRed;
                                }
                                Xwins();
                            }
                        }//end of Horizonal win
                        
                        //Left to right diagonal
                        if (buttonArray[j + (j*root)].Text == "X")
                        {
                            d1Count++;
                            if (d1Count == root)
                            {
                                for (int z = (root - 1); z >= 0; z--)
                                {
                                    buttonArray[z + (z * root)].BackColor = Color.IndianRed;
                                }
                                Xwins();
                            }
                        }//end of LTR win
                        //Right to left diagonal
                        if (buttonArray[(j*(root - 1)) + (root - 1)].Text == "X")
                        {
                            d2Count++;
                            if (d2Count == root)
                            {
                                for (int z = (root - 1); z >= 0; z--)
                                {
                                    buttonArray[(z*(root - 1)) + (root - 1)].BackColor = Color.IndianRed;
                                }
                                Xwins();
                            }
                        }//end of RTL win
                            
                        //Vertical win
                        if (buttonArray[i + (root*j)].Text == "X")
                        {
                            vCount++;
                            if (vCount == root)
                            {
                                for (int z = (root - 1); z >= 0; z--)
                                {
                                    buttonArray[i + (root*z)].BackColor = Color.IndianRed;
                                }
                                Xwins();
                            }
                        }//end of vert win
                        
                    }//end of for j loop
            }//end of for loop
            
        }//end of CheckXWinner
