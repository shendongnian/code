    private void TxtMark4_KeyPress(object sender, KeyPressEventArgs e)
    {
        int? tmp = null; //signed to allow it to be assigned the value of null
        if(int.TryParse(txtMark4.Text,out tmp)){
            if(tmp >=0 && tmp <= 100){
            //Here the number is between 0 and 100
            }
            else{//Number is below 0 or above 100
                if(tmp > 100){
                    TxtMark4.Text = TxtMark4.Text.remove(2); //This will forcefully make it less or equal to 100
                    DisplayLabel.text = "Numbers between 0-100 only";
                }
                else{
                    TxtMark4.Text = ""; //and if its below 0 it will not be displayed
                    DisplayLabel.text = "Numbers between 0-100 only";
                }
            }
        }
        else{//Not a number
            //Return some indicator to the user
            DisplayLabel.text = "numbers only";
        }
    }
