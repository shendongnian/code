    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                this.myComboBox1.TheButton = this.button1;
    
                this.myComboBox1.Items.AddRange( new string[] {
                    "Monday",
                    "Tuesday",
                    "Wednesday",
                    "Thursday",
                    "Friday",
                    "Saturday",
                    "Sunday"
                } );
    
                button1.Enabled = false;
            }
        }
    
        public class MyComboBox : ComboBox
        {
            public Control TheButton { get; set; }
    
            public MyComboBox()
            {
            }
    
            bool IsValidItemSelected
            {
                get { return null != this.SelectedItem; }
            }
    
            protected override void OnValidated( EventArgs e )
            {
                if ( null != TheButton )
                {
                    TheButton.Enabled = this.IsValidItemSelected;
                    TheButton.Focus();
                }
    
                base.OnValidated( e );
            }
    
            protected override void OnTextChanged( EventArgs e )
            {
                if ( null != TheButton )
                {
                    TheButton.Enabled = this.IsValidItemSelected;
                }
    
                base.OnTextChanged( e );
            }
        }
    }
