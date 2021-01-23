     private void Form2_FormClosing(Object sender, FormClosingEventArgs e) 
    {
       DialogResult answer = MessageBox.Show("[Your text]",MessageBoxButtons.YesNo)
     
       if(answer == DialogResult.Yes)
         {
             
           Form1.check=True; //if button yes is clicked 
                             // set the form1 check variable to True and closes form2
           
         }
       else
         {
              Form1.check=False; //if button no is clicked 
                               // set the form1 check variable to False and cancel form 
                               // closing                                  
              e.Cancel=True;
         }
         
    }
