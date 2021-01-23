      namespace YourNameSpace
        {
        public delegate void RichTextBoxDelegate(string text);
           public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            
            
            public void ACText(string s)
            {
               ConsoleText.AppendText(s); 
            }
            
        
    // In Some Method Call MCDonald's form
    public void ShowMcDonalds()
    {
       RichTextBoxDelegate deleg = new RichTextBoxDelegate(ACText);
       MCdonalds ob = new McDonalds(deleg);
        ob.show();
    
    }
        }
        }
   
