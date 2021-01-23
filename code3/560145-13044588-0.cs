    public partial class Main : Form
    {
         //make it internal, if UpdateDialog in the same assembly, and it only one that        would use it. In other words hide it for outside world.
         internal void function1()  
         {
             doing_stuff_here();
         }
     ....
    }
    public partial class UpdateDialog : Form        
    {
          private MainForm _main = null;
          public UpdateDialog (MainForm main) { //Accept only MainForm type, _not_ just a Form
            _main = main;
          }
    
          private void button2_Click(object sender, EventArgs e)
          {
                _main.function1(); //CALL
          }
    }
