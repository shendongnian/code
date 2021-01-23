    //Code on your form 2
    private string strClass;
    private int iRollNo;
    ..
      public string StrClass
        {
          get { return this.strClass; }
          set { this.strClass= value; }
         }
 
        public int IRollNo
        {
          get { return this.iRollNo; }
          set { this.iRollNo= value; }
        }
     //code on form1
      Form2 objFrom2 = new Form2();
      objFrom2.strClass= "10th";
      objFrom2.iRollNo= 1;
      objFrom2.ShowDialog(); //show the form.
