    public partial class Form1 : BaseLanguageForm
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "English")
            {
                this.TriggerLanguageChange("en");
            }
            else if (comboBox1.SelectedItem.ToString() == "Spanish")
            {
                this.TriggerLanguageChange("es-ES");
            }
            else if (comboBox1.SelectedItem.ToString() == "French")
            {
                this.TriggerLanguageChange("fr-FR");
            }
        }
        
        
    }
    /// <summary>
    /// The event that should be passed whenever language needs to be changed
    /// </summary>
    public class LanguageArgs:EventArgs
    {
        string _languageSymbol;
        /// <summary>
        /// Gets the language symble.
        /// </summary>
        public string LanguageSymbol
        {
            get { return _languageSymbol; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageArgs"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        public LanguageArgs(string symbol)
        {
            this._languageSymbol = symbol;
        }
    }
    /// <summary>
    /// A base class that your class should derivative from
    /// </summary>
    public class BaseLanguageForm:Form
    {
        /// <summary>
        /// Triggers the language change event.
        /// </summary>
        /// <param name="languageSymbol">The language symbol.</param>
        protected void TriggerLanguageChange(string languageSymbol)
        {
            if (Form1.onLanguageChanged != null)
            {
                LanguageArgs args = new LanguageArgs(languageSymbol);
                Form1.onLanguageChanged(this, args);
            }
        }
        /// <summary>
        /// This should be triggered whenever the combo box value chages
        /// It is protected, just incase you want to do any thing else specific to form instacne type
        /// </summary>
        protected static event EventHandler<LanguageArgs> onLanguageChanged;
        /// <summary>
        /// This will be called from your form's constuctor 
        /// (you don't need to do anything, the base class constuctor is called automatically)
        /// </summary>
        public BaseLanguageForm()
        {
            //registering to the event
            BaseLanguageForm.onLanguageChanged += new EventHandler<LanguageArgs>(BaseLanguageForm_onLanguageChanged);
        }
        /// <summary>
        /// The function that was regidtered to the event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        void BaseLanguageForm_onLanguageChanged(object sender, LanguageArgs e)
        {
            string lang = e.LanguageSymbol;
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager crm = new ComponentResourceManager(typeof(Form1));
                crm.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
    }
