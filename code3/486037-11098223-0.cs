    public class MyForm : Form
    {
        public void ShowModalAsync()
        {
            this.Invoke(new Action(()=> {
                  ShowDilaog(..);
            }));  
        }
    }
