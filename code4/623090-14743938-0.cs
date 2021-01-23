    private void TxtMark4_KeyPress(object sender, KeyPressEventArgs e)
    {
        int? tmp = null; //signed to allow it to be assigned the value of null
        if(int.TryParse(txtMark4.Text(),out tmp)){
            if(tmp >=0 && tmp <== 100){
            //Here the number is between 0 and 100
            }
            else{
            //Number is below 0 or above 100
            }
        }
        else{//Not a number
        //Return some indicator to the user
        }
    }
