    public class Form2 : Form {
      private IMyCustomType parentSelectedOption;
      ...
      public void InitParameters(IMyCustomType selectedOption) 
      {
          parentSelectedOption = selectedOption;
      }
    }
    public class Form1 : Form {
         ....
         var form2 = new Form2();
         form2.InitParameters(selectedOption);
         form2.Show();
    }
