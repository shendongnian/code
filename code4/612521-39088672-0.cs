    Public void processing (){
        if (RadioButton.Checked == True ){     
        // here i have to Assign the Value from Enum to This:
        Class.eStatus =(Status) Enum.Parse(typeof(Status), ClassRadioButton1Status);
        }
    }
