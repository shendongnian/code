    //Here is the test
    public partial class Form1 : Form {
       public Form1(){
         InitializeComponent();
         rb1.Size = new Size(200,100);
         rb2.Size = rb1.Size;
         rb2.Left = rb1.Right + 5;
         rb1.Parent = rb2.Parent = this;
         rtb1.BindScroll(rtb2);       
         //try populating some data for both the richtextboxes
         for(int i = 0; i < 200; i++)
            rtb1.Text += Guid.NewGuid() + "\r\n";
         rtb2.Text = rtb1;
         //now try scrolling the rtb1
         //I suggest you should add WM_MOUSEWHEEL = 0x20a into the if statement
         //something like this: if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL || m.Msg == WM_MOUSEWHEEL) ...
       }
       RichTextBoxSynchronizedScroll rtb1 = new RichTextBoxSynchronizedScroll();
       RichTextBoxSynchronizedScroll rtb2 = new RichTextBoxSynchronizedScroll();
    }
    //That's all
    
    
    
