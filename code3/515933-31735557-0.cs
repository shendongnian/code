    public class MyForm : Form
    {
       public MyForm()
       {
          Load += (o, e) => { Width -=1; Width +=1; };
       }
    }
