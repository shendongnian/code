{            
                    
                    
                    dif = int(datediff("D", Convert.ToDateTime("01/" + Q101m.text + "/" + Q101y.Text), (Convert.ToDateTime(Vdate.text)))/365.25)
                    //If dif < 15 Or dif > 49 
                    {
                    MessageBox.Show("xxxxxxx");
                    Q101m.Focus();
                    }
                }
