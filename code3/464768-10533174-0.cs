    bool read = true;
                        string finalText="";
                        int j = 1;
                        int lengthMax = 200;
                       
                        while(read)
                        {
                            string textnya = comment.Shape.TextFrame.Characters(j, lengthMax).Text;
                            finalText = finalText+textnya;
                            if (textnya.Length < lengthMax)
                            {
                                read = false;
                            }
                            else
                            {
                                j = j + lengthMax;
                            }
                           
                        }
                        MessageBox.show(finalText); 
