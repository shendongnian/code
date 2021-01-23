    namespace WindowsFormsApplication1
    {
        public class LoadText : Form1
        {
            //new label declared as a static var
            public static Label pLabel;
            //this method runs when your form opens
            public LoadTextForm() 
            {
                pLabel = Label1; //assign your private label to the static one
            }
            //Any time getText() is used, the label text updates no matter where it's used
            public static void getText()
            {
               Form1.textReplaceWith("New label1 text", pLabel); //Form1 method's used 
            }
        }
    }
