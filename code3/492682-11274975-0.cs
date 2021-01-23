    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using log4net;
    using IntraNext.Win32.Config;
    
    namespace AlpineAccess.Plugins.SecureTalkPlugin
    {
    
        public partial class SecureTextBox : TextBox
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(SecureTextControl));
    
            private static readonly Color COLOR_FOCUSED = Color.Yellow;
            private static readonly Color COLOR_FOCUSED_MANUALMODE = Color.PaleGreen;
    
            private FocusEvent focusListener;
            private Field field;
            private bool isInManualMode;
            private EventHandler textChanged;
            private string RealText;
    
            public SecureTextBox()
            {
                InitializeComponent();
                RealText = "";
            }
    
            internal void Initialize(Field field, FocusEvent focusList, EventHandler textChanged)
            {
                this.focusListener = focusList;
                this.textChanged = textChanged;
                this.field = field;
    
                this.Enter += new EventHandler(SecureTextBox_Enter);
                this.Leave += new EventHandler(SecureTextBox_Leave);
                this.TextChanged += new EventHandler(SecureTextBox_TextChanged);
    
                MenuItem mnuItemNew = new MenuItem();
                mnuItemNew.Text = "&Clear";
    
                //THIS textbox HAS a context menu ALREADY BUT here we assign a new context menu to
                //our text box to replace the old one which had cut, paste etc. that we don't want
                //the agent using...
                this.ContextMenu = new ContextMenu();
                this.ContextMenu.MenuItems.Add(mnuItemNew);
    
                mnuItemNew.Click += new EventHandler(clear_Click);
    
                SwitchModes();
            }
    
            void SecureTextBox_TextChanged(object sender, EventArgs e)
            {
                if(isInManualMode) //make sure if in manual mode, we keep changes up to date in realText field
                    RealText = Text;
                textChanged(sender, e);
            }
    
            void clear_Click(object sender, EventArgs e)
            {
                ClearAll();
            }
    
            internal void SetManualMode(bool inManual)
            {
                if (isInManualMode == inManual)
                    return; //we don't care if there is no change so return;
    
                isInManualMode = inManual;
                SwitchModes();
            }
    
            void SecureTextBox_Leave(object sender, EventArgs e)
            {
                log.Info("exiting=" + field.Variable);
                focusListener(field.Variable, false, this.RealText);
                BeginInvoke(new MethodInvoker(delegate()
                {
                    ChangeBackground();
                }
                ));            
            }
    
            void SecureTextBox_Enter(object sender, EventArgs e)
            {
                log.Info("entering=" + field.Variable );
                focusListener(field.Variable, true, this.RealText);
                BeginInvoke(new MethodInvoker(delegate()
                {
                    ChangeBackground();
                }
                ));
            }
    
            private void SwitchModes()
            {
                SetupTextInBox();
                ChangeBackground();
            }
    
            private void SetupTextInBox()
            {
                if (isInManualMode)
                {
                    this.ReadOnly = false;
                    base.Text = RealText;
                }
                else if (!field.IsSecure)
                {
                    this.ReadOnly = true;
                    string temp = RealText;
                    base.Text = temp;
                    Invalidate();
                    log.Info("txt=" + base.Text + " temp=" + temp);
                }
                else //not manual mode and IsSecure so mask it and make it readonly
                {
                    this.ReadOnly = true;
                    MaskData();
                }
            }
    
            private void MaskData()
            {
                log.Debug("mask=" + this.field.NumBeginDigitsToMaskSpecified + " num=" + field.NumBeginDigitsToMask + " txtLen=" + RealText.Length);
                int numDigitsToMask = RealText.Length;
                if (this.field.NumBeginDigitsToMaskSpecified && this.field.NumBeginDigitsToMask < RealText.Length)
                {
                    int numDigits = this.field.NumBeginDigitsToMask;
                    string maskedPart = "".PadLeft(numDigits, '●');
                    string unmasked = RealText.Substring(numDigits);
                    string full = maskedPart + unmasked;
                    base.Text = full;
                }
                else
                {
                    log.Debug("masking all digits");
                    base.Text = "".PadLeft(RealText.Length, '●');
                }
            }
    
            private void ChangeBackground()
            {
                if (isInManualMode)
                    SetManualModeColor();
                else
                    SetNonManualModeColor();
            }
    
            private void SetNonManualModeColor()
            {
                if (this.Focused)
                    this.BackColor = COLOR_FOCUSED;
                else
                    this.BackColor = Control.DefaultBackColor;
            }
    
            private void SetManualModeColor()
            {
                if (this.Focused)
                    this.BackColor = COLOR_FOCUSED_MANUALMODE;
                else
                    this.BackColor = Control.DefaultBackColor;
            }
    
            public void AppendDTMFDigit(string digit)
            {
                log.Info("manualmode="+isInManualMode+" specified=" + field.MaxSpecified + " someone appending dtmf digit on field=" + field.Variable + " fieldMax=" + field.Max + " len=" + RealText.Length);
    
                if (isInManualMode)
                    return;
                else if (field.MaxSpecified && RealText.Length >= field.Max)
                    return; //shortcut out since we can't exceed max digits
    
                BeginInvoke(new MethodInvoker(delegate()
                {
                    RealText = RealText + digit;
                    SetupTextInBox();
                }
                )); 
            }
    
            internal void ClearAll()
            {
                log.Info("Cleared textbox for =" + field.Variable);
                base.Text = "";
                RealText = "";
                SetError("");
            }
    
            public override string Text
            {
                get
                {
                    return RealText;
                }
                set
                {
                    if (value == null)
                        throw new ArgumentException("Not allowed to set RealText to null.  Set to empty string instead");
                    RealText = value;
                }
            }
    
            /**
             * Set to "" to clear the error or set anything to make valid
             */
            public void SetError(string error)
            {
                if (!this.IsHandleCreated)
                    return;
    
                SecureTextBox box = this;
                //set to "" to clear the error
                BeginInvoke(new MethodInvoker(delegate()
                {
                    errorProvider1.SetError(box, error);
                }));
            }
        }
    }
