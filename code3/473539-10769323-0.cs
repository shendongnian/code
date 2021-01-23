    public class MyContext : ApplicationContext
    {
       private List<Form> forms;     
 
       private static MyContext context = new MyContext();
 
       private MyContext()
       {
          forms = new List<Form>();
          ShowForm1();
       }
      
       public static void ShowForm1()
       {
          Form form1 = new Form1();
          context.AddForm(form1);
          form1.Show();
       }
       private void AddForm(Form f)
       { 
          f.Closed += FormClosed;
          forms.Add(f);
       }
       private void FormClosed(object sender, EventArgs e)
       {
          Form f = sender as Form;
          if (form != null)
              forms.Remove(f);
          if (forms.Count == 0)
             Application.Exit();
       }          
    }
