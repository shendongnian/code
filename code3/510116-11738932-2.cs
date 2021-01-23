    public class LocalizedForm : Form
    {
        /// <summary>
        /// Occurs when current UI culture is changed
        /// </summary>
        [Browsable(true)]
        [Description("Occurs when current UI culture is changed")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Category("Property Changed")]
        public event EventHandler CultureChanged;
        protected CultureInfo culture;
        protected ComponentResourceManager resManager;
        /// <summary>
        /// Current culture of this form
        /// </summary>
        [Browsable(false)]
        [Description("Current culture of this form")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CultureInfo Culture
        {
            get { return this.culture; }
            set
            {
                if (this.culture != value)
                {
                    this.ApplyResources(this, value);
                    this.culture = value;
                    this.OnCultureChanged();
                }
            }
        }
        public LocalizedForm()
        {
            this.resManager = new ComponentResourceManager(this.GetType());
            this.culture = CultureInfo.CurrentUICulture;
        }
        private void ApplyResources(Control parent, CultureInfo culture)
        {
            this.resManager.ApplyResources(parent, parent.Name, culture);
            foreach (Control ctl in parent.Controls)
            {
                this.ApplyResources(ctl, culture);
            }
        }
        protected void OnCultureChanged()
        {
            var temp = this.CultureChanged;
            if (temp != null)
                temp(this, EventArgs.Empty);
        }
    }
