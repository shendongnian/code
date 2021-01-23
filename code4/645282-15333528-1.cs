     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                richTextBox1.DragDrop += new DragEventHandler(richTextBox1_DragDrop);
                richTextBox1.AllowDrop = true;
            }
    
            void richTextBox1_DragDrop(object sender, DragEventArgs e)
            {
                object filename = e.Data.GetData("FileDrop");
                if (filename != null)
                {
                    var list = filename as string[];
    
                    if (list != null && !string.IsNullOrWhiteSpace(list[0]))
                    {
                        richTextBox1.Clear();
                        richTextBox1.LoadFile(list[0], RichTextBoxStreamType.PlainText);
                    }
    
                }
            }
