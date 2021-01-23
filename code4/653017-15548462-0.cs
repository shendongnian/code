    public class TextBoxInputMaskBehavior : Behavior<TextBox>
    {
        private WeakPropertyChangeNotifier _notifier;
        #region DependencyProperties
        public static readonly DependencyProperty InputMaskProperty =
          DependencyProperty.Register("InputMask", typeof(string), typeof(TextBoxInputMaskBehavior), null);
        public string InputMask
        {
            get { return (string)GetValue(InputMaskProperty); }
            set { SetValue(InputMaskProperty, value); }
        }
        public static readonly DependencyProperty PromptCharProperty =
           DependencyProperty.Register("PromptChar", typeof(char), typeof(TextBoxInputMaskBehavior), new PropertyMetadata('_'));
        public char PromptChar
        {
            get { return (char)GetValue(PromptCharProperty); }
            set { SetValue(PromptCharProperty, value); }
        }
        public static readonly DependencyProperty ResetOnSpaceProperty =
           DependencyProperty.Register("ResetOnSpace", typeof(bool), typeof(TextBoxInputMaskBehavior), new PropertyMetadata(false));
        public bool ResetOnSpace
        {
            get { return (bool)GetValue(ResetOnSpaceProperty); }
            set { SetValue(ResetOnSpaceProperty, value); }
        }
        #endregion
        public MaskedTextProvider Provider { get; private set; }
       
        public TextBoxInputMaskBehavior()
        {
            //defaults
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObjectLoaded;
            AssociatedObject.PreviewTextInput += AssociatedObjectPreviewTextInput;
            AssociatedObject.PreviewKeyDown += AssociatedObjectPreviewKeyDown;
            DataObject.AddPastingHandler(AssociatedObject, Pasting);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= AssociatedObjectLoaded;
            AssociatedObject.PreviewTextInput -= AssociatedObjectPreviewTextInput;
            AssociatedObject.PreviewKeyDown -= AssociatedObjectPreviewKeyDown;
            DataObject.RemovePastingHandler(AssociatedObject, Pasting);
        }
        /*
        Mask Character  Accepts  Required?  
        0  Digit (0-9)  Required  
        9  Digit (0-9) or space  Optional  
        #  Digit (0-9) or space  Required  
        L  Letter (a-z, A-Z)  Required  
        ?  Letter (a-z, A-Z)  Optional  
        &  Any character  Required  
        C  Any character  Optional  
        A  Alphanumeric (0-9, a-z, A-Z)  Required  
        a  Alphanumeric (0-9, a-z, A-Z)  Optional  
           Space separator  Required 
        .  Decimal separator  Required  
        ,  Group (thousands) separator  Required  
        :  Time separator  Required  
        /  Date separator  Required  
        $  Currency symbol  Required  
        In addition, the following characters have special meaning:
        Mask Character  Meaning  
        <  All subsequent characters are converted to lower case  
        >  All subsequent characters are converted to upper case  
        |  Terminates a previous < or >  
        \  Escape: treat the next character in the mask as literal text rather than a mask symbol  
        */
        void AssociatedObjectLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Provider = new MaskedTextProvider(InputMask, CultureInfo.CurrentCulture);
            this.Provider.PromptChar = this.PromptChar;
            this.Provider.SkipLiterals = true;
            this.Provider.ResetOnSpace = this.ResetOnSpace;
            this.Provider.Set(AssociatedObject.Text);
            AssociatedObject.Text = GetProviderText();
            //seems the only way that the text is formatted correct, when source is updated
            //AddValueChanged for TextProperty in a weak manner
            this._notifier = new WeakPropertyChangeNotifier(this.AssociatedObject, TextBox.TextProperty);
            this._notifier.ValueChanged += new EventHandler(this.UpdateText);          
        }
        void AssociatedObjectPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = true;
            this.TreatSelectedText();
            var position = this.GetNextCharacterPosition(AssociatedObject.CaretIndex);
            if (Keyboard.IsKeyToggled(Key.Insert))
            {
                if(!this.Provider.Replace(e.Text, position))
                {
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
            }
            else
            {
                if(!this.Provider.InsertAt(e.Text, position))
                {
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
            }
            var nextposition = this.GetNextCharacterPosition(position + 1);
            this.RefreshText(nextposition);
        }
        void AssociatedObjectPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)//handle the space
            {
                e.Handled = true;
                this.TreatSelectedText();
                var position = this.GetNextCharacterPosition(AssociatedObject.CaretIndex);
                if (!this.Provider.InsertAt(" ", position))
                {
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
                this.RefreshText(AssociatedObject.CaretIndex + 1);
            }
            if (e.Key == Key.Back && AssociatedObject.CaretIndex > 0)//handle the back space
            {
                e.Handled = true;
                //wenn etwas markiert war und der nutzer Backspace klickt soll nur das markierte verschwinden
                if(this.TreatSelectedText())
                {
                    this.RefreshText(AssociatedObject.CaretIndex);
                    return;
                }
                
                var denDavor = AssociatedObject.CaretIndex - 1;
                if(this.Provider.IsEditPosition(denDavor))
                {
                    if (!this.Provider.RemoveAt(denDavor))
                    {
                        System.Media.SystemSounds.Beep.Play();
                        return;
                    }
                }
                this.RefreshText(AssociatedObject.CaretIndex - 1);
            }
            if (e.Key == Key.Delete)//handle the delete key
            {
                e.Handled = true;
                //wenn etwas markiert war und der nutzer Delete klickt soll nur das markierte verschwinden
                if (this.TreatSelectedText())
                {
                    this.RefreshText(AssociatedObject.CaretIndex);
                    return;
                }
                var position = AssociatedObject.CaretIndex;
                if (this.Provider.IsEditPosition(position))
                {
                    if (!this.Provider.RemoveAt(position))
                    {
                        System.Media.SystemSounds.Beep.Play();
                        return;
                    }
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
                this.RefreshText(AssociatedObject.CaretIndex);
            }
        }
        /// <summary>
        /// Pasting prüft ob korrekte Daten reingepastet werden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = (string)e.DataObject.GetData(typeof(string));
                this.TreatSelectedText();
                var position = GetNextCharacterPosition(AssociatedObject.CaretIndex);
                if (!this.Provider.InsertAt(pastedText, position))
                {
                    System.Media.SystemSounds.Beep.Play();
                }
                else
                {
                    this.RefreshText(position);
                }
            }
            e.CancelCommand();
        }
        private void UpdateText(object sender, EventArgs eventArgs)
        {
            //check Provider.Text + TextBox.Text
            if (this.Provider.ToDisplayString().Equals(AssociatedObject.Text))
                return;
            //use provider to format
            var success = this.Provider.Set(AssociatedObject.Text);
            //ui and mvvm/codebehind should be in sync
            this.SetText(success ? GetProviderText() : AssociatedObject.Text);
        }
        /// <summary>
        /// Falls eine Textauswahl vorliegt wird diese entsprechend behandelt.
        /// </summary>
        /// <returns>true Textauswahl behandelt wurde, ansonsten falls </returns>
        private bool TreatSelectedText()
        {
            if (AssociatedObject.SelectionLength > 0)
            {
                this.Provider.RemoveAt(AssociatedObject.SelectionStart, AssociatedObject.SelectionStart + AssociatedObject.SelectionLength - 1);
                return true;
            }
            return false;
        }
        private void RefreshText(int position)
        {
            SetText(GetProviderText());
            AssociatedObject.CaretIndex = position;
        }
        private void SetText(string text)
        {
            AssociatedObject.Text = String.IsNullOrWhiteSpace(text) ? String.Empty : text;
        }
        private int GetNextCharacterPosition(int caretIndex)
        {
            var start = caretIndex;
            var position = this.Provider.FindEditPositionFrom(start, true);
            if (position == -1)
                return start;
            else
                return position;
        }
        private string GetProviderText()
        {
            //wenn noch gar kein Zeichen eingeben wurde, soll auch nix drin stehen
            //könnte man noch anpassen wenn man masken in der Oberfläche vllt doch haben will bei nem leeren feld
            return this.Provider.AssignedEditPositionCount > 0
                       ? this.Provider.ToDisplayString()
                       : this.Provider.ToString(false, false);
        }
    }
