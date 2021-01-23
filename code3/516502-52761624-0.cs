    namespace reusebleplaceholdertextbox
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // implementation
                CustomPlaceHolderTextbox myCustomTxt = new CustomPlaceHolderTextbox(
                    "Please Write Text Here...", Color.Gray, new Font("ARIAL", 11, FontStyle.Italic)
                    , Color.Black, new Font("ARIAL", 11, FontStyle.Regular)
                    );
    
                myCustomTxt.Multiline = true;
                myCustomTxt.Size = new Size(200, 50);
                myCustomTxt.Location = new Point(10, 10);
                this.Controls.Add(myCustomTxt);
            }
        }
    
        class CustomPlaceHolderTextbox : System.Windows.Forms.TextBox
        {
            public string PlaceholderText { get; private set; }
            public Color PlaceholderForeColor { get; private set; }
            public Font PlaceholderFont { get; private set; }
    
            public Color TextForeColor { get; private set; }
            public Font TextFont { get; private set; }
    
            public CustomPlaceHolderTextbox(string placeholdertext, Color placeholderforecolor,
                Font placeholderfont, Color textforecolor, Font textfont)
            {
                this.PlaceholderText = placeholdertext;
                this.PlaceholderFont = placeholderfont;
                this.PlaceholderForeColor = placeholderforecolor;
                this.PlaceholderFont = placeholderfont;
                this.TextForeColor = textforecolor;
                this.TextFont = textfont;
                if (!string.IsNullOrEmpty(this.PlaceholderText))
                {
                    SetPlaceHolder(true);
                    this.Update();
                }
            }
    
            private void SetPlaceHolder(bool addEvents)
            {
                if (addEvents)
                {  
                    this.LostFocus += txt_lostfocus;
                    this.Click += txt_click;
                }
    
                this.Text = PlaceholderText;
                this.ForeColor = PlaceholderForeColor;
                this.Font = PlaceholderFont;
            }
    
            private void txt_click(object sender, EventArgs e)
            {
                // IsNotFirstClickOnThis:
                // if there is no other control in the form
                // we will have a problem after the first load
                // because we dont other focusable control to move the focus to
                // and we dont want to remove the place holder
                // only on first time the place holder will be removed by click event
                RemovePlaceHolder();
                this.GotFocus += txt_focus;
                // no need for this event listener now
                this.Click -= txt_click;
            }
    
            private void RemovePlaceHolder()
            {
                this.Text = "";
                this.ForeColor = TextForeColor;
                this.Font = TextFont;
            }
            private void txt_lostfocus(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(this.Text))
                {
                    // set placeholder again
                    SetPlaceHolder(false);
                }
            }
    
            private void txt_focus(object sender, EventArgs e)
            {
                if (this.Text == PlaceholderText)
                {
                    // IsNotFirstClickOnThis:
                    // if there is no other control in the form
                    // we will have a problem after the first load
                    // because we dont other focusable control to move the focus to
                    // and we dont want to remove the place holder
                    RemovePlaceHolder();
                }
            }
        }
    }
