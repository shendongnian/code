            [WebSysDescription("WebControl_BackColor")]
            [WebCategory("Appearance")]
            [DefaultValue(typeof (Color), "")]  // this needs to be changed
            [TypeConverter(typeof (WebColorConverter))]
            public virtual Color BackColor
            {
              get
              {
                if (!this.ControlStyleCreated)
                  return Color.Empty;
                else
                  return this.ControlStyle.BackColor;
              }
              set
              {
                this.ControlStyle.BackColor = value;
              }
            }
  
