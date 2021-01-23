    class WinForm : Form
    {
       public delegate void updateTextBoxDelegate(String textBoxString); // delegate type 
       public updateTextBoxDelegate updateTextBox; // delegate object
    
       void updateTextBox1(string str ) { textBox1.Text = str1; } // this method is invoked
       
       public WinForm()
       {
          ...
          updateTextBox = new updateTextBoxDelegate( updateTextBox1 ); // initialize delegate object
        ...
        Server serv = new Server();
    
    }
