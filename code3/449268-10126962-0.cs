    static class Program
     {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {   
        using (Login login = new Login())
        {
         login.StartPosition = FormStartPosition.CenterScreen;
         if (login.ShowDialog() == DialogResult.OK)
         {      
          Application.Run(new Form1(login.strUserName)); //passing the userName to the constructor of form1 (see bellow)
         }
       }
      }
     }
    
    //form1:
     public partial class Form1 : Form
     {  
      string userName; 
      public Form1(string _strUser)
      {   
       InitializeComponent();
       userName = _userName; //a local variable of a form1 class has hold user`s name (userName - which u can call it from within the form1 class!
      }
     }
