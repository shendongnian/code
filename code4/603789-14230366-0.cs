        //PSEUDO CODE
        bool setDateFromOutside = false; //GLOBAL VARIABLE
        
        public void TextBox_Leave(...){
         setDateFromOutside = true;   //SET TRUE
    
         dateTimePicker.Value = newDate; //SOME VALUE
    
         setDateFromOutside = false;  //SET TRUE
        }
    
        public void DateTimePicker_ValueChanged(...){
    
           if(setDateFromOutside)
              return;
        }
